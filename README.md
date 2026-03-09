**ALERT : JUST FOR LEARNING PURPOSE**

This guide explains, step by step from scratch, how to:

1. Set up a V8 environment on Windows
2. Build V8 (`v8_monolith.lib`)
3. Run a simple C++ runtime from `runtime.cpp`

## 1. Prerequisites

Install the following components:

1. Visual Studio 2022
2. `Desktop development with C++` workload
3. Python 3.x
4. Git

Make sure these commands are available in your terminal:

```powershell
python --version
git --version
```

Notes:

1. To compile C++, run commands from `x64 Native Tools Command Prompt for VS 2022` or Visual Studio Developer PowerShell.
2. V8 builds require a large amount of disk space (tens of GB).

## 2. Install depot_tools

`depot_tools` is the official Chromium/V8 toolset for fetching source code and syncing dependencies.

```powershell
cd D:\dev
git clone https://chromium.googlesource.com/chromium/tools/depot_tools.git
```

Add it to `PATH` (example):

```powershell
setx PATH "$env:PATH;D:\dev\depot_tools"
```

Close and reopen your terminal after updating `PATH`.

Verify:

```powershell
where fetch
where gclient
where gn
where ninja
```

## 3. Fetch V8 source

```powershell
cd D:\dev
fetch v8
cd v8
gclient sync
```

This step can take a while because it downloads a large source tree and dependencies.

## 4. Generate V8 build configuration

Create the x64 release output config:

```powershell
python tools/dev/v8gen.py x64.release
```

Edit build arguments:

```powershell
gn args out.gn/x64.release
```

Use this `args.gn` (minimal stable setup for embedding):

```gn
is_debug = false
target_cpu = "x64"
v8_monolithic = true
v8_use_external_startup_data = false
is_component_build = false
symbol_level = 0
```

Quick explanation:

1. `v8_monolithic = true`: produces one large library (`v8_monolith.lib`) that is easier to link.
2. `is_component_build = false`: static-style build (better for simple embedding).
3. `v8_use_external_startup_data = false`: startup data is not split into external files.

## 5. Build V8

```powershell
ninja -C out.gn/x64.release v8_monolith
```

Important output paths:

1. `D:\dev\v8\out.gn\x64.release\obj\v8_monolith.lib`
2. Headers in `D:\dev\v8\include`

## 6. Prepare the runtime project (this workspace)

Current workspace files:

1. `main.cpp`
2. `README.md`

Initial goal: compile `main.cpp` to initialize V8 and run a simple JavaScript snippet.

Minimal runtime capabilities:

1. Create an `Isolate`
2. Create a `Context`
3. Run JS code (`"1 + 2"`)
4. Print the result to the console

## 7. Compile `main.cpp` with MSVC

In a Developer x64 terminal (adjust V8 paths as needed):

```powershell
cl /std:c++17 /EHsc /I D:\dev\v8\include main.cpp /link /LIBPATH:D:\dev\v8\out.gn\x64.release\obj v8_monolith.lib winmm.lib dbghelp.lib shlwapi.lib
```

If the linker requests additional system libraries, add them based on the error output.

## 8. Run the binary

If compilation succeeds:

```powershell
.\main.exe
```

Expected minimal output (example):

```text
3
```

## 9. Upgrade to a file-based runtime

After the minimal runtime works, continue with:

1. Add argument parsing: `myjs script.js`
2. Read JS files from disk
3. Compile and run JS source
4. Show error and stack trace on exceptions

## 10. Next milestones

Suggested roadmap:

1. Built-in global function `print(...)`
2. Built-in `readFile(path)`
3. Event loop (integrate `libuv`)
4. Promise/microtask draining
5. ES Module loader

## Quick troubleshooting

1. `fetch`/`gclient` not recognized: check `depot_tools` in `PATH`, then open a new terminal.
2. Build fails due to toolchain issues: ensure VS C++ workload is installed.
3. Link errors from `cl`: verify `include`, `LIBPATH`, and that `v8_monolith.lib` exists.

## Official references

1. V8 docs: https://v8.dev/docs
2. V8 build instructions: https://v8.dev/docs/build

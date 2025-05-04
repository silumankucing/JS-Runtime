let printMessage name =
    printfn $"Hello there, {name}!"

// 'names' is inferred to be a sequence of strings.
let printNames names =
    for name in names do
        printMessage name

let names = [ "Ana"; "Felipe"; "Emillia" ]
printNames names
                              
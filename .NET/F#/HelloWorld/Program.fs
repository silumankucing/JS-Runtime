let printMessage name =
    printfn $"Hello there, {name}!"

let printNames names =
    for name in names do
        printMessage name

let names = [ "Ana"; "Felipe"; "Emillia" ]

printNames names
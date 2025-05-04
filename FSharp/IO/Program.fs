open System

let calculator () =
    printfn "Enter the first number:"
    let num1 = Console.ReadLine() |> float

    printfn "Enter the operator (+, -, *, /):"
    let operator = Console.ReadLine()

    printfn "Enter the second number:"
    let num2 = Console.ReadLine() |> float

    let result =
        match operator with
        | "+" -> num1 + num2
        | "-" -> num1 - num2
        | "*" -> num1 * num2
        | "/" -> 
            if num2 <> 0.0 then num1 / num2
            else 
                printfn "Division by zero is not allowed."
                Double.NaN
        | _ -> 
            printfn "Invalid operator."
            Double.NaN

    printfn $"The result is: {result}"

[<EntryPoint>]
let main argv =
    calculator ()
    0 // Return an integer exit code
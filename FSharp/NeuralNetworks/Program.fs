open System

// Activation function (Sigmoid)
let sigmoid x = 1.0 / (1.0 + exp(-x))

// Derivative of the sigmoid function
let sigmoidDerivative x = x * (1.0 - x)

// Perceptron training function
let train inputs outputs epochs learningRate =
    let mutable weights = [| 0.5; 0.5 |] // Initialize weights
    let mutable bias = 0.5 // Initialize bias

    for epoch in 1 .. epochs do
        for i in 0 .. inputs.Length - 1 do
            // Forward pass
            let input = inputs.[i]
            let target = outputs.[i]
            let weightedSum = Array.zip input weights |> Array.sumBy (fun (x, w) -> x * w) + bias
            let output = sigmoid weightedSum

            // Backpropagation
            let error = target - output
            let adjustment = error * sigmoidDerivative output
            weights <- Array.map2 (fun w x -> w + learningRate * adjustment * x) weights input
            bias <- bias + learningRate * adjustment

    weights, bias

// Perceptron prediction function
let predict inputs weights bias =
    let weightedSum = Array.zip inputs weights |> Array.sumBy (fun (x, w) -> x * w) + bias
    sigmoid weightedSum

[<EntryPoint>]
let main argv =
    // Training data (AND gate)
    let inputs = [| [| 0.0; 0.0 |]; [| 0.0; 1.0 |]; [| 1.0; 0.0 |]; [| 1.0; 1.0 |] |]
    let outputs = [| 0.0; 0.0; 0.0; 1.0 |]

    // Train the perceptron
    let epochs = 10000
    let learningRate = 0.1
    let weights, bias = train inputs outputs epochs learningRate

    // Test the perceptron
    printfn "Trained weights: %A" weights
    printfn "Trained bias: %f" bias

    for input in inputs do
        let prediction = predict input weights bias
        printfn "Input: %A, Prediction: %f" input prediction

    0 // Return an integer exit code
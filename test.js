// Simple runtime smoke test
function fib(n) {
  if (n <= 1) return n;
  return fib(n - 1) + fib(n - 2);
}

const a = 7;
const b = 5;
const sum = a + b;
const seq = fib(10);

`sum=${sum}, fib10=${seq}`;
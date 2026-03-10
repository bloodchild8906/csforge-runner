using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ╔══════════════════════════════════════════╗
// ║  CSFORGE v3  ·  Ctrl+Enter to Run       ║
// ║  Ctrl+Space  ·  IntelliSense            ║
// ╚══════════════════════════════════════════╝

Console.WriteLine("⬡ CSFORGE v3");
Console.WriteLine($".NET {Environment.Version}  ·  {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC");
Console.WriteLine(new string('─', 48));
Console.WriteLine();

// Async demo
async Task<List<int>> PrimesAsync(int limit) =>
    await Task.Run(() => Enumerable.Range(2, limit - 1)
        .Where(n => !Enumerable.Range(2, (int)Math.Sqrt(n) - 1).Any(d => n % d == 0))
        .ToList());

var primes = await PrimesAsync(50);
Console.WriteLine($"Primes ≤ 50: {string.Join(", ", primes)}");
Console.WriteLine();

// Records + switch expressions
record Shape(string Name, double A, double B = 0);
static double Area(Shape s) => s.Name switch {
    "circle"    => Math.PI * s.A * s.A,
    "rect"      => s.A * s.B,
    "triangle"  => 0.5 * s.A * s.B,
    _           => 0
};

var shapes = new[] {
    new Shape("circle", 5),
    new Shape("rect", 4, 7),
    new Shape("triangle", 3, 8),
};

Console.WriteLine("Shapes:");
foreach (var sh in shapes.OrderByDescending(Area))
    Console.WriteLine($"  {sh.Name,-10} area = {Area(sh):F2}");

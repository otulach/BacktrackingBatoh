```

BenchmarkDotNet v0.14.0, macOS Ventura 13.6.7 (22G720) [Darwin 22.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method       | Mean       | Error    | StdDev   |
|------------- |-----------:|---------:|---------:|
| RunRekursion | 1,608.7 ns | 24.61 ns | 33.68 ns |
| RunTable     |   307.6 ns |  2.03 ns |  1.69 ns |

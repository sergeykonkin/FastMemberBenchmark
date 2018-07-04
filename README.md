# [fast-member](https://github.com/mgravell/fast-member) benchmark

```
BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.492 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-4790 CPU 3.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
Frequency=3507508 Hz, Resolution=285.1027 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2671.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2671.0


           Method |      Mean |     Error |    StdDev |
----------------- |----------:|----------:|----------:|
 Get_PropertyInfo | 120.87 ns | 2.4424 ns | 3.3432 ns |
   Get_FastMember |  26.77 ns | 0.6047 ns | 0.6210 ns |
 Set_PropertyInfo | 213.40 ns | 4.3003 ns | 4.6013 ns |
   Set_FastMember |  32.57 ns | 0.7291 ns | 1.2769 ns |
```
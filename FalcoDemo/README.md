# Demo application to try to use Fun.Blazor in falco for serving html content


## Benchmark

|step|ok stats|
|---|---|
|name|`fetch fun-form`|
|request count|all = `54211`, ok = `54211`, RPS = `903.5`|
|latency|min = `0.37`, mean = `1.09`, max = `5.97`, StdDev = `0.28`|
|latency percentile|50% = `1.03`, 75% = `1.19`, 95% = `1.58`, 99% = `2.06`|

|step|ok stats|
|---|---|
|name|`fetch falco-form`|
|request count|all = `54567`, ok = `54567`, RPS = `909.4`|
|latency|min = `0.26`, mean = `1.08`, max = `9.3`, StdDev = `0.28`|
|latency percentile|50% = `1.02`, 75% = `1.17`, 95% = `1.57`, 99% = `2.08`|

# Setting "Dialect" to "1" seems to be ignored

This repository contains a simple example to help replicate an issue we're experiencing using the official Embarcadaro .NET InterbaseClient.

## Problem
Attempting to alter/create a procedure containing the "DATE" keyword throws an exception, this only seems to be a problem when executing this statement through the .NET driver (I can confirm that the Server is also set to Dialect 1, and the statement executes properly with IBConsole and IBExpert).

## Investigation
After debugging the InterBaseSql.Data.InterbaseClient package myself, I was able to determine that the underlying error is actually `"DATE data type is now called TIMESTAMP"`, which tells me the issue likely has something to do with the Dialect.

## Documentation
> The DATE data type contains both time and date information and is interpreted as TIMESTAMP; the name has changed but the meaning has not. Dialect 1 clients expect the entire timestamp to be returned. In dialect 1, DATE and TIMESTAMP are identical.

https://docwiki.embarcadero.com/InterBase/2020/en/Understanding_SQL_Dialects

## Console Output
![image](https://user-images.githubusercontent.com/8741942/208167397-97ef569f-0ff8-4752-aeaa-865de002caed.png)

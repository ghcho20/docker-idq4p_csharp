# This folder
## is reserved to be shared with the container
of this docker image to provide persistent storage for source.

All work will be gone when a container is removed. Then any work done to build applications will not remain.

This folder is mounted to /workspace inside the container for developers to work on .NET application source.

If you want other location for workspace, change volume option in ../run.bat file.
> `../run.bat`
>
> docker run --rm --name %CNAME% -v "__./ws__:/workspace" -it %INAME%
>
>> change `./ws` to other path you want to share with the container

# Create IDQ4P C# project
1. mkdir <proj folder>
1. cd <proj folder>
1. dotnet new idq4p
```
    The template "IDQ4P Console App over ZMQ and MsgPack" was created successfully.
```
4. ls
```
    idq4p.cs        idq4pcs.csproj
```

# Build & run IDQ4P C# application
1. cd <proj folder>
1. dotnet run [-c Release]
```
    Hello World!
```

# Check application dependency
1. cd <proj folder>
1. dotnet ls package [--include-transitive]
```
    Project 'idq4pcs' has the following package references
        [netcoreapp3.0]: 
        Top-level Package      Requested   Resolved 
        > MsgPack.Cli          1.0.1       1.0.1
        > NetMQ                4.0.0.207   4.0.0.207
```
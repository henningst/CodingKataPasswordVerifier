# Instructions


## Install .NET Core

* Go to <https://dot.net> click on Download .NET Core 1.0 and download ".NET Core 1.0.1 - VS 2015 Tooling Preview 2".

 This will install both the .NET Core SDK for Windows and the Tooling needed for Visual Studio.

## Create a new minimal Console Application

* Make a new directory for the solution. I.e. c:\projects\PasswordVerifier

* Make a new directory for the project. I.e. c:\projects\PasswordVerifier\src

* Run `dotnet new` to create a minimal .NET Core Console App.

* Try to run `dotnet run`. 

 You will see you get an error message because the required dependencies have not been restored yet.

 ```
error NU1009: The expected lock file doesn't exist. Please run "dotnet restore" to generate a new lock file.
```

* Have a look at project.json. Here you can see the dependencies needed for your application to run. Do as the error message tells you, and run “dotnet restore” in order to generate a new lock file and restore the dependencies.

* Now run `dotnet restore` as the error message says to restore the dependnecies.

... The console sould now output that the lock file has been generated and that the restore completed.

* You should now be able to run the console application by executing `dotnet run` and you should see "Hello World!" printet to the console.





## Create a unit test project

Now we have a working minimal console application. Let's create a unit test project so we can test our code.

* Make a new directory for the test project. I.e. c:\projects\PasswordVerifier\test

* In the `test` directory, create a new file called `project.json` and add the following content to it:
 ```
{
    "version": "1.0.0-*",
    "testRunner": "xunit",
    "dependencies": {
        "xunit": "2.2.0-beta2-build3300",
        "dotnet-test-xunit": "2.2.0-preview2-build1029"
    },
    "frameworks": {
        "netcoreapp1.0": {
            "dependencies": {
                "Microsoft.NETCore.App": {
                    "type": "platform",
                    "version": "1.0.1"
                }
            }
        }
    }
}
```

* Add an emtpy class definition in the test project where we will later add our unit tests. Call it `c:\project\PasswordVerifier\test\PasswordVerifierTests.cs`

* You should now be able to restore dependencies and run the empty test project similar to the console app. First run `dotnet restore`.
 
 When the dependnecies have been restored, you can run `dotnet test` to actually execute all tests.

 Make sure you get the expected output from xUnit. It should look like this:

 ```
Project test (.NETCoreApp,Version=v1.0) will be compiled because inputs were modified
Compiling test for .NETCoreApp,Version=v1.0

Compilation succeeded.
    0 Warning(s)
    0 Error(s)

Time elapsed 00:00:00.8641640


xUnit.net .NET CLI test runner (64-bit .NET Core win10-x64)
  Discovering: test
  Discovered:  test
=== TEST EXECUTION SUMMARY ===
   test.dll  Total: 0
SUMMARY: Total: 1 targets, Passed: 1, Failed: 0.
```

## Start doing some actual TDD

Our setup is now done and you are ready to do some actual TDD.

* If we look at the Kata instructions, we can see that the first feature we need to implement is a `Verify()` 
function that make sure the password should be larger than 8 chars. So let's add a new test for that.

 In the PasswordVerifierTests add a new test method like this:

 ```
[Fact]
public void Verify_WhenPasswordLongerThan8Chars_ShouldReturnTrue() {
    var passwordVerifier = new PasswordVerifier();
    Assert.True(passwordVerifier.Verify("mypassword"));
}
```        

 This will test the "happy path" making sure the Verify method returns true when the password is longer than 8 chars.

 Now run your tests by executing `dotnet test`.

 This will fail due to several reasons. 

 * First it will fail because we have not yet added a reference to our Console Application project in the test project.
 Do this by adding `"src": "1.0.0-*"` to the list of dependencies in the test project.

 Run the tests again. It still fails because we haven't imported the namespace where the PasswordVerifier class is defined in the test class.

 Add `using ConsoleApplication;` in the `PasswordVerifierTests class.

 Run the test again.

 Still fails because we haven't yet implemented the `Verify` method, so you'll see this error:

 ```
 error CS1061: 'PasswordVerifier' does not contain a definition for 'Verify' and no extension method 'Verify' accepting a first argument of type 'PasswordVerifier' could be found (are you missing a using directive or an assembly reference?)
 ```

 * Go ahead and implement the simplest way possible to get the test passing. This could i.e. be done by adding the `Verify` method
 with one string parameter and just return true without any logic.

 Run the test again, and you'll see it passes. 

 ```
 === TEST EXECUTION SUMMARY ===
   test  Total: 1, Errors: 0, Failed: 0, Skipped: 0, Time: 0,125s
SUMMARY: Total: 1 targets, Passed: 1, Failed: 0.
```

 **Yay! You have your first passing unit test! :D**

* The code doesn't really do much useful yet, so you should probably add another test to make sure an exception is thrown If
the password is 8 characters or shorter.

 You start by adding a test for this!

* Add another test called `Verify_WhenPassword8CharsOrShorter_ShouldThrowException`. This test should assert that an exception
is thrown if the password is 8 chars or shorter. Exceptions can be asserted like this:

 ```
Assert.Throws<ArgumentException>(() => passwordVerifier.Verify("shortpw"));
```
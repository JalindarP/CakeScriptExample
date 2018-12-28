#tool nuget:?package=Wyam
#addin nuget:?package=Cake.Wyam
#addin nuget:?package=Cake.Git
#tool nuget:?package=Cake.Git
#load "./file.cake"
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////
Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});
Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});
///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////
Task("Default")
.Does(() => {
   Information("Hello Cake!");
});
// Task("clone").Does(()=>{
//    GitClone("","")
// })
Task("Build")
.IsDependeeOf("Clean")
.Does(()=>
{   
   DotNetCoreBuild(Constant.path);
});
Task("Clean").Does(()=>
{
   DotNetCoreClean(Constant.path);
});
Task("Docs").Does(()=>
{
 
});
RunTarget(target);

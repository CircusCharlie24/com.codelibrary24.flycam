# Unity Custom Package Template

A template for making custom unity packages.

## Adding Runtime code

1. Create a folder called Runtime
2. Add Scripts and other work, you can add folders like Script, Prefabs, Resources etc - just like you do for projects, keep it clean
3. Inside the Runtime folder. create an Assembly Definition file - name it as CompanyName.PackageName ( for example: CodeLibrary24.CustomPackageTemplate )
4. Add the root namespace as CompanyName.PackageName

## Adding Editor code

1. Create a folder called Editor
2. Add Scripts and other work, you can add folders like Script, Prefabs, Resources etc - just like you do for projects, keep it clean
3. Inside the Editor folder. create an Assembly Definition file - name it as CompanyName.PackageName.Editor ( for example: CodeLibrary24.CustomPackageTemplate.Editor )
4. Make sure to select only Editor in the platform and keep de-select other platforms
5. Add the root namespace as CompanyName.PackageName

## Adding dependencies

1.Add the following in the package.json file:-
  
 "dependencies": {
     "com.codelibrary24.dummydependency": "1.0.0",
     "com.codelibrary24.dummydependency": "1.0.1"
 },


 ## Adding Samples
 
 1. Create a folder called Sample~
 2. Inside Sample~ create a folder called SampleFolder_01
 3. If you want to add one more sample, Inside Sample~ create a folder called SampleFolder_02 (you can create as many as you want)
 4. Add the following in the package.json file:-
 
     "samples": [
        {
            "displayName": "Dummy Sample 01",
            "description": "This is a Dummy description",
            "path": "Samples~/SampleFolder_01"
        },
        {
            "displayName": "Dummy Sample 02",
            "description": "This is a Dummy description",
            "path": "Samples~/SampleFolder_02"
        }
    ],
 
 6. Samples~ is not shown inside unity as long as the '~' is part of the name, hence when you want to edit the samples, remove the ~ and add it back when you are done and ready to publish the package.
    

## Important
1. Package names should always be lower case for example "com.companyname.packagename"
2. If you face an issue related to GUIDs and get a message saying that Guid for some folder or file already exists, just uninstall the packages, go to Unity package cache and delete all the folders with the same name as the server URL (check all sub-folders too). To go to the unity cache filder just type "**%LOCALAPPDATA%\Unity\cache**" in the Windows search bar. 

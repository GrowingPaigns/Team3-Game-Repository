## MonoGame.Aseprite

MonoGame.Aseprite is an extension for MonoGame Framework to import the .json file 
produced by Aseprite using the content pipeline, with a collection of classes to 
support rending the animation.

## IMPORTANT

In order for the content pipeline to import the .json file appropriatly, you will 
need to add the MonoGame.Aseprite.ContentPipline.dll to the Content Pipeline Tool 
for your project.  If you do not do this, then you will not be able to build the files 
in the Content Pipeline Tool.

The following steps outline how to do this.

1.  Open the Content Pipeline Tool for your project.  (This should be the Content.mgcb 
    in the Conent folder of your project)

2.  In the Project panel, click the root "Content"

3.  In the Properties, scroll down to the References proprety and click the box to the 
    right of it to open the Refrence Editor dialog

4.  On the Reference Editor dialog, click the Add button to open the Open File dialog

5.  Navigate to the root folder of your project and find the "packages" folder.

6.  Inside the "packages", open the MonoGame.Aseprite.1.0.0, then open the "content" folder.

7.  Select the "MonoGame.Aseprite.ContentPipeline.dll" and the click Open.

You can close the windows out now.  Be sure to save if asked to by the Content Pipeline Tool.


## Thank you

For more information on MonoGame.Aseprite and using it, be sure to visit the project page at https://gitlab.com/manbeardgames/monogame-aseprite


# 1801Games

Space Dash is a mobile 2D-Platformer game where the player has to survive for as long as possible while collecting items and powerups to attain the highest score possible. 

# Demo video link: https://sccapstone.github.io/1801Games/

## External Requirements
* [Visual Studio Code] (https://code.visualstudio.com) 
  * VS Code Extensions Needed:
    * C# Programming Language
    * C# FixFormat 
    * GitHub Pull Requests and Issues
    * Unity3D Meta Files Watcher 
    * vscode-icons

* [Unity Hub and Unity (Currently version 2019.4.11)] (https://unity3d.com/get-unity/download)
  * Unity Asset(s) Needed:
    * GitHub for Unity 

## Setup
VS Code:
 * Once you have VS code installed, in order to properly program our game you need to enter the extensions screen (Ctrl+Shift+X) and download the extensions above.

Unity:
 * To add the project itself, in the "Projects" screen, you will want to hit the "Add" and locate the files that you just downloaded from GitHub and hit "Select Folder." Unity will download the selected files, and after that you will be able to access the most recent version of the work-in-progress game. 
 
 After Downloading and The project opens. Look at the top of the screen for the play button. Hitting play will allow you to use the features that are currently implemented into the game. To reset it simply press play again. To look at the other screens like settings or play again go to the assets in the bottom left and click on scenes. Open the desired scene and youll see how it was created. 

## Running 
* To run the game and test the controls, under the root of the repository, double click on the "2d Platformer" exe file.

* To modify the game, open Unity and add the "1801Games" folder as a project.

In order to properly run the application, it is best to have VS Code and Unity opened at the same time. So as you update your code, Unity updates along with it and will notify you of possible syntax errors. When the application is running, at that point you can check for runtime errors and quality assurance test as well. 

## Testing
* All Tests are located in Assets/Tests/

    * Both unit and behaviorals are located in ../EditMode and ../PlayMode. In Unity, edit mode tests are where non-runtime tests belong and play mode are where runtime tests belong.
    
        * In Unity, the test files are located in the exact same spot.
    
    * How to run all tests:
    
        * In Unity, go to Window/General/Test Runner. The test runner will then open.
        
        * You will not have to import any assemblies. We use the predefined assemblies NUnit tests and Unity Test Runner.
        
        * Once you are set, locate the C# script you are testing inside of the test runner and select it. Once selected, click "run selected" and your test will return. You can also select "run all" to run all tests.

## DEV MODE
For Developer Mode:

Developer mode is for both PC and Android testing. You are able to move around and play the game the same way you would in the regular game, however, as for any other dev/cheat
mode, you are granted invincibility and unrestricted movement. Also, none of the scores or stats achieved in developer mode are recorded in order to keep your authentic stats
and scores in tact. 


## Style Guide
We follow Google's C# style guide. (https://google.github.io/styleguide/csharp-style.html)

# Authors

Tariq Scott (tariqs@email.sc.edu)

Bradley Williamson (bw5@email.sc.edu)

Nick Bautista (bautisn@email.sc.edu)

Davonte Blakely (lblakely@email.sc.edu)

Savannah Sun (yiqian@email.sc.edu)

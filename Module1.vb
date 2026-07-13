'TODO:1. Change Procedure name to your own procedure name

'TODO:2.  Add Json package to the resources

'TODO:3. Create A Project Class

'TODO:4.  Create A Json file for the Project Class

'TODO:5.  Refactor writeFile procedure to take a string for data input

'TODO:6.  move the input variable up to the global class variable access

'TODO:7.  Seralize Project Class

'TODO:8.  Deseralize The Project json Class

'TODO:9.  Use snippets (insert comment) to add comments to procedures and functions

'TODO:10.Refactor your code to create subfolders in a separate procedure

'TODO:11.Remove reference comments

Module Module1

    'READ: 'More information on file reading and writing in the coursebook: pg 68: FileRead

    'https://drive.google.com/file/d/1qwb9Sq3bf9sWPdAUeiFX_xM1Knb4Ikpp/view

    Dim ProjectName As String

    Dim FullDirectory As String

    Sub Main()

        Dim input As String = 0

        While input <> "exit"
            Console.WriteLine(" Enter Command")
            ProjectName = Console.ReadLine

            Console.WriteLine("Please enter a command  Exit | Create")

            input = Console.ReadLine.ToString()

            If input = "Create" Then

                MakeProjectFolders()

            End If


        End While

    End Sub

    Private Sub MakeProjectFolders()

        'TODO: Add Json database to store project information

        'TODO: Change MakeP2PProjectFolders to MakeProjectFolders

        Dim newFolderPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop

        If ProjectName = "" Then

            ProjectName = " Not Set\"

        End If

        '  My.Computer.FileSystem.CreateDirectory(newFolderPath + ProjectName)

        CreateProjectFolder(newFolderPath, ProjectName)

        newFolderPath += "\" + ProjectName

        FullDirectory = newFolderPath
        'TODO:Adjust the folder to organize playlist data if needed
        CreateProjectFolder(newFolderPath, "\Docs")
        CreateProjectFolder($"{newFolderPath}\Docs", "Ref")
        CreateProjectFolder($"{newFolderPath}\Docs", "Word")
        CreateProjectFolder($"{newFolderPath}\Docs", "PDF")
        CreateProjectFolder($"{newFolderPath}\Docs", "Excel")
        CreateProjectFolder($"{newFolderPath}\Docs", "Cloud")

        CreateProjectFolder(newFolderPath, "\Assets")
        CreateProjectFolder($"{newFolderPath}\Assets", "Art")
        CreateProjectFolder($"{newFolderPath}\Assets", "Images")

        WriteFile("ReadMe.txt", newFolderPath)
        WriteFile("ReadMe.txt", $"{newFolderPath}\Docs")



        Console.WriteLine("Project created in: " + FullDirectory)

    End Sub
    Private Sub WriteFile(fileName As String, location As String)

        'Ref:https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files-with-a-streamwriter

        If fileName <> "" Then

            Dim file As System.IO.StreamWriter

            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)
            file.WriteLine("# Week 6 Folder Maker App

## Purpose

Explain what your app creates and why it is useful.

This app creates music playlists to organize the users music into different genres, different, vibes, etc.

## How To Run

Explain how to open and run the VB.NET project.

to start the project the user will have to first have to name a playlist in order to create it, afterwards 
they can either add music to said playlist or different playlists within that playlist to organize it even more
ex: (main playlist: study music, Miniplaylist(s): classical, lofi, etc)

## Folder Structure Created

List the folders and files your app generates

The app will generate 2 different types of folders.

1. main playlist folders: these folders organize and store the music the user wants to save.

2. optional mini folders: these mini folders will be inside the main folders and are created to act as an option to 
organize the users main folder by further catagorizing the music.

## Story to App Connection
Explain how your story or backstory led to this utility.

My backstory led to this utility because the lack of free music playing apps inspired me to create my own music playing app

## Team Members
List all team members, or write (Individual project).
(individual project)

## Screenshots
List or include screenshots showing the app, generated folders, README file, Git repo, and Discord post.")
            file.Close()
        End If

    End Sub

    Sub CreateProjectFolder(newFolderPath As String, ProjectName As String)
        My.Computer.FileSystem.CreateDirectory(newFolderPath + "\" + ProjectName)
    End Sub
End Module

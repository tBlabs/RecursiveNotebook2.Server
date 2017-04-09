@ECHO off

git remote add origin https://github.com/tBlabs/RecursiveNotebook2.Server.git

@ECHO Adding...
git add .

SET /p commitMessage=Enter commit message: 

@ECHO Commiting...
git commit -m "%commitMessage%"

@ECHO Pulling...
git pull origin master

@ECHO Pushing...
git push origin master

@ECHO Publish done.


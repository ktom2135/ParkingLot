#! zsh

sed -i "" -e "s/dotnet-project-template-test/$1Test/" -e "s/dotnet-project-template/$1/" .gitignore
sed -i "" "s/dotnet_project_template_test/$1Test/" dotnet-project-template-test/dotnet-project-template-test.csproj
sed -i "" "s/dotnet_project_template/$1/" dotnet-project-template/dotnet-project-template.csproj
sed -i "" "s/Dotnet_project_template_test/$1Test/" dotnet-project-template-test/UnitTest1.cs
sed -i "" "s/Dotnet_project_template/$1/" dotnet-project-template/Class1.cs dotnet-project-template-test/UnitTest1.cs
sed -i "" "s/dotnet-project-template/$1/g" dotnet-project-template-test/dotnet-project-template-test.csproj
sed -i "" "s/dotnet-project-template-test/$1Test/g" dotnet-project-template.sln
sed -i "" "s/dotnet-project-template/$1/g" dotnet-project-template.sln

mv dotnet-project-template-test/dotnet-project-template-test.csproj dotnet-project-template-test/$1Test.csproj
mv dotnet-project-template/dotnet-project-template.csproj dotnet-project-template/$1.csproj
mv dotnet-project-template-test $1Test
mv dotnet-project-template $1
mv dotnet-project-template.sln $1.sln
mv .vs/dotnet-project-template .vs/$1

rm README.md
rm rename.sh
git add .
git commit -m "chore: rename project to $1"

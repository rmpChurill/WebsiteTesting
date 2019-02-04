#!/bin/bash

rm -rf Migrations/
rm main.db

dotnet ef migrations add InitialCreate
dotnet ef database update
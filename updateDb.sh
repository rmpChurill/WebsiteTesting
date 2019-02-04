#!/bin/bash

dotnet ef migrations add Update
dotnet ef database update
# Roman Calendar (RomanDateTime)
![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/danielhulse/f547068d-79a5-4079-aae2-e86fd6d4f6cb/1/master.svg?label=master)
![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/danielhulse/f547068d-79a5-4079-aae2-e86fd6d4f6cb/3/develop.svg?label=develop)
![GitHub last commit](https://img.shields.io/github/last-commit/DanTHulse/RomanDateTime.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Nuget](https://img.shields.io/nuget/v/RomanDateTime.svg?label=stable)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/RomanDateTime.svg?label=develop)

An implementation of the Roman calendar system. The calendar system used is post-Julian reforms (46 BC) however it represents dates in the [proleptic Gregorian calendar](https://en.wikipedia.org/wiki/Proleptic_Gregorian_calendar) for ease of conversion for now. It represents all the systems and quirks the calendar had, and is as accurate as I could make it from my research.
If there are any features or issues with current systems feel free to raise issues if they are not already mentioned here!

## Features
I mirrored the functionality of `System.DateTime` so the bulk of public methods are copies and all do functionally the same thing. The most obvious examples are `.AddDays()` `.AddMonths()` etc.

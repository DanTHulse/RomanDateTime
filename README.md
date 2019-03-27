# Roman Calendar (RomanDateTime)
![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/danielhulse/f547068d-79a5-4079-aae2-e86fd6d4f6cb/1/master.svg?label=master)
![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/danielhulse/f547068d-79a5-4079-aae2-e86fd6d4f6cb/3/develop.svg?label=develop)
![GitHub last commit](https://img.shields.io/github/last-commit/DanTHulse/RomanDateTime.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Nuget](https://img.shields.io/nuget/v/RomanDateTime.svg?label=stable)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/RomanDateTime.svg?label=develop)

An implementation of the Roman calendar system. The calendar system used is post-Julian reforms (46 BC) however it represents dates in the [proleptic Gregorian calendar](https://en.wikipedia.org/wiki/Proleptic_Gregorian_calendar) for ease of conversion for now. It represents all the systems and quirks the calendar had, and is as accurate as I could make it from my research, though I am *not* a historian and got a C in GSCE History so I accept that there could be mistakes or inaccuracies! If there are any features or issues with current systems feel free to raise issues if they are not already mentioned here!

## Features
I mirrored the functionality of `System.DateTime` so the bulk of public methods are copies and all do functionally the same thing.
```csharp
// new date with year - 1st January 2019
var dateY = new RomanDateTime(2019);
// new date with year and month - 1st March 2019
var dateYM = new RomanDateTime(2019, 3);
// new date with year, month and day - 15th March 2019
var dateYMD = new RomanDateTime(2019, 3, 15);
// new date with year, month, day and hour - 1pm 15th March 2019
// you can only specify upto the Hour since Romans didn't subdivide the hours
var dateAndHour = new RomanDateTime(2019, 3, 15, 13);
// new date with DateTime
var dateTime = new DateTime(2019, 3, 15);
var romanDateTime = new RomanDateTime(dateTime);
```
Any of these constructors can also use the optional [Eras](../master/RomanDate/Enums/Eras.cs) enum, by default the era will be set to `Eras.AD` but you can specify a BC date like so
```csharp
// new BC date - 15th March 47 BC
var bcDate = new RomanDateTime(47, 3, 15, Eras.BC)
```
*It's worth noting that while there is no year 0 in the Gregorian calendar, for simplicity I am treating a 0 in the year as if it's **1 BC** but `RomanDateTime(1, Eras.BC);` will also be 1 BC*

You can also get some static values from the struct
```csharp
// the current date and time
var now = RomanDateTime.Now;
// the lowest convential date and time allowed with DateTime i.e. 1/1/0001
var min = RomanDateTime.MinValue;
// the lowest date and time possible, taken by using the maximum DateTime but in BC i.e. 31/12/9999 BC
var absMin = RomanDateTime.AbsoluteMinValue;
// the highest date and time possible with DateTime i.e. 31/12/9999
var max = RomanDateTime.MaxValue;
```
There's also some helper methods available to extend the functionality that I didn't see as fitting within the main struct as they are of potentially less importance to the workings of the calendar
`.NextSetDay()``.PreviousSetDay()` both will move the instance to the next or last set (sacred) day of the month
`.NextNundinae()``.PreviousNundinae()` both will move the instance to the next or last nundinae (market) day.

And finally since I needed this anyway, there's a set of Roman Numeral conversion helpers that works in both the more common (to us) subtractive method (i.e. 4 = IV) as well as the additive method (4 = IIII) which may have been more common at the time. Also the way it's written, I think, would allow almost any combination of numerals, even those never used such as IC = 99. But don't quote me on that I've not tested all permutations.

## Calendar Details
Here is some of the things to note about the way the calendar worked at this point in history, hopefully explaining some of the quirks. Like I say I am not a historian and just casually researched this in my spare time so I accept that there could be mistakes, if there are any I am keen to fix them as I tried to get as accurate as I could!
### Years
The year that is shown by default in this implementation is that of the AD or BC year as this is the one most recognisable to us. But it's important to know that the Romans would have more commonly used the names of the two consuls in office that year to represent the year, so for example the year 46 BC would be known by a citizen as the "Year of the Consulship of Caesar and Lepidus" or "The year of Caesar and Lepidus" for short. I unfortunately don't have consular naming in this package. 

There was also a numbering of the years but I'm unsure of how commonly it was used at this time: *ab urbe condita* or From the Founding of the City (city meaning Rome). This happened in around 753 BC so I have included in the class the year as it would be in AUC. Though dates before 753 BC will return nothing.
### Months
The calendar during the Republic had the 12 months we are used to, though there is an older system where there were only 10, and the time between the end of December and beginning of March was likely unorganised. This is why months like October are the 10th month even though Octo is latin for 8. All of the months in English retain their Latin names mostly intact and after the reforms of Julius Caesar had all the same numbers of days we have now.
Each month had 3 sacred days on which important festivals or observances would be held:
* Kalendae (always the first of the month)
* Nonae (always 8 days before the Idus, 9 days to a Roman - see Days below!)
* Idus (13th or 15th of the month)
### Weeks
A Roman week was 8-days long instead of seven and each day was marked on the calendar with a *Nundinal letter* (A-H). These days would be sequential, in that the week would progress A->B->...G->H->A. One of these letters would be chosen by the priests for a two-year cycle to be the *Nundinae* which represented the market day in Rome (and other cities around the Empire) this is essentially like the weekend and citizens would take a break from their work in the farms to travel to Rome to sell their goods. The Romans had superstitions about the Nundinae which where focused on the *Nonae*, one of the sacred days of the month. Bad luck would come if the Nundinae fell on the Nonae, also the 1st (or Kalendae) of January, so care was taken to choose a letter that would prevent this type of clash.
### Days
Romans didn't track days the same way we do now, a Roman would never say it's the 15th of March for example. This is because the 15th March is the Ides, so they would say: "Idibus Martiis" or "The Ides of March". In fact all days are referred to by their relation to the next nearest sacred day (if it isn't currently one).

So, the 13th March is "ante diem III Idus Martias" or "3 days before the Ides of March".

Straight away you might think: "Why is the 13th of March **3** days before the 15th and not **2**?" that's because Romans counted  days *inclusively* meaning they counted the day they are on to get to the day they want. So: 13th, 14th, 15th = 3 Days.

Now lets say 14th March: "pridie Idus Martiis" or "The day before the Ides of March" (could also say "The Eve of").
Finally 16th March: "ante diem XVII Kalendas Apriles" or "17 days before the Kalends of April".

This is the second curve ball, after the Ides the next sacred day is next months Kalends, so you start counting down to that instead. This has the side effect of you spending half the month of March referencing April when talking about the date. It's a little confusing at first but you get the hang of it pretty quickly
### Hours
Romans treated sunrise as Hour 1 and sunset as the end of Hour 12. This was true thoughout the year which has the effect of making an hour longer in the summer than in the winter (this is represented in a way within this project as well so 1pm will give a different hour in the summer than in the winter).

Night time was tracked by the *Vigila* or watches, the night was split into four equal watches, after sunset, before midnight, after midnight and before sunrise. I couldn't find if Romans would refer to the passage of time at night with hours also, but I included them as a seperate field anyway, with Hour 1 of night beginning at sunset and Hour 12 of night ending at sunrise. You can tell them apart as the normal hours are written as "hora IV" for Hour 4 and "hora noctis VII" for Hour 7 of night.
### Prefixes
Just a quick section of the prefixes, they've already been seen above in Days, but there are 3:
* ante diem (shortened to a.d.)
* pridie (shortened to pr.)
* ante diem bis (shortened to a.d. bis)

Sacred days have no prefix.

*ante diem bis* is special in that it is used to denote the leap day, unlike our calendar where we add the 29th to February, this calendar instead inserts the leap day **before** "a.d. VI Kalendas Martias" or "6 days before the Kalends of March"

This gives us "ante diem bis VI Kalendas Martias" or "6 days before the Kalends of March...twice? again?" I actually don't know how to translate that in a way that makes sense but essentially they repeat "a.d. VI Kalendas Martias" so you end up with:
* a.d. VII Kalendas Martias
* a.d. bis VI Kalendas Martias
* a.d. VI Kalendas Martias
* a.d. V Kalendas Martias

Whereas non-leap years look like this:
* a.d. VII Kalendas Martias
* a.d. VI Kalendas Martias
* a.d. V Kalendas Martias

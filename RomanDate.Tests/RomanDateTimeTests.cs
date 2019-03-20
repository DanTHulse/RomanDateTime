using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using RomanDate.Enums;
using RomanDate.Helpers;
using System;

namespace RomanDate.Tests
{
    [TestClass]
    public class RomanDateTimeTests
    {
        [TestMethod]
        public void RomanDateTime_ReturnsDayInRomanCalendar()
        {
            var thirdOfMay = new RomanDateTime(2019, 5, 3).Day;
            var fifteenthOfMarch = new RomanDateTime(2019, 3, 15).Day;
            var fourthOfDecember = new RomanDateTime(2019, 12, 4).Day;
            var firstOfJune = new RomanDateTime(2019, 6, 1).Day;

            var twentyThirdOfFebruary = new RomanDateTime(2017, 2, 23).Day;
            var twentyEighthOfFebruary = new RomanDateTime(2017, 2, 28).Day;
            var twentyFourthOfFebruary = new RomanDateTime(2017, 2, 24).Day;
            var twentyFifthOfFebruary = new RomanDateTime(2017, 2, 25).Day;

            Assert.AreEqual("ante diem V Nonas Maias", thirdOfMay);
            Assert.AreEqual("Idibus Martiis", fifteenthOfMarch);
            Assert.AreEqual("pridie Nonas Decembribus", fourthOfDecember);
            Assert.AreEqual("Kalendis Iuniis", firstOfJune);

            Assert.AreEqual("ante diem VII Kalendas Martias", twentyThirdOfFebruary);
            Assert.AreEqual("pridie Kalendis Martiis", twentyEighthOfFebruary);
            Assert.AreEqual("ante diem VI Kalendas Martias", twentyFourthOfFebruary);
            Assert.AreEqual("ante diem V Kalendas Martias", twentyFifthOfFebruary);
        }

        [TestMethod]
        public void RomanDateTime_ReturnsDayInRomanCalendarLeapYear()
        {
            var twentyThirdOfMarch = new RomanDateTime(2016, 3, 23).Day;
            var thirtyFirstOfMarch = new RomanDateTime(2016, 3, 31).Day;
            var twentyFourthOfMarch = new RomanDateTime(2016, 3, 24).Day;
            var twentyFifthOfMarch = new RomanDateTime(2016, 3, 25).Day;

            var twentyThirdOfFebruary = new RomanDateTime(2016, 2, 23).Day;
            var twentyNinthOfFebruary = new RomanDateTime(2016, 2, 29).Day;
            var twentyFourthOfFebruary = new RomanDateTime(2016, 2, 24).Day;
            var twentyFifthOfFebruary = new RomanDateTime(2016, 2, 25).Day;

            Assert.AreEqual("ante diem X Kalendas Apriles", twentyThirdOfMarch);
            Assert.AreEqual("pridie Kalendis Aprilibus", thirtyFirstOfMarch);
            Assert.AreEqual("ante diem IX Kalendas Apriles", twentyFourthOfMarch);
            Assert.AreEqual("ante diem VIII Kalendas Apriles", twentyFifthOfMarch);

            Assert.AreEqual("ante diem VII Kalendas Martias", twentyThirdOfFebruary);
            Assert.AreEqual("pridie Kalendis Martiis", twentyNinthOfFebruary);
            Assert.AreEqual("ante diem bis VI Kalendas Martias", twentyFourthOfFebruary);
            Assert.AreEqual("ante diem VI Kalendas Martias", twentyFifthOfFebruary);
        }

        [TestMethod]
        public void RomanDateTime_ReturnsNewDateInRomanCalendarForNewDate()
        {
            var empty = new RomanDateTime();

            Assert.AreEqual("Kalendis Ianuariis I", $"{empty.Day} {empty.Year}");
        }

        [TestMethod]
        public void RomanDateTime_ReturnsNewDateInRomanCalendarForMinMaxValues()
        {
            var min = RomanDateTime.MinValue;
            var max = RomanDateTime.MaxValue;

            Assert.AreEqual("Kalendis Ianuariis I", $"{min.Day} {min.Year}");
            Assert.AreEqual("pridie Kalendis Ianuariis MMMMMMMMMCMXCIX", $"{max.Day} {max.Year}");
        }

        [TestMethod]
        public void GetTime_ReturnsCorrectWinterTimes()
        {
            var winterDate = new LocalDateTime(2019, 12, 1, 0, 0);

            var TwelvePM = new RomanDateTime(winterDate.PlusHours(12)).Hour;
            var TwelveFifteenPM = new RomanDateTime(winterDate.PlusHours(12).PlusMinutes(15)).Hour;
            var OneAM = new RomanDateTime(winterDate.PlusHours(1)).Hour;
            var NineAM = new RomanDateTime(winterDate.PlusHours(9)).Hour;
            var SevenPM = new RomanDateTime(winterDate.PlusHours(19)).Hour;
            var FourAM = new RomanDateTime(winterDate.PlusHours(4)).Hour;
            var FiveThrityPM = new RomanDateTime(winterDate.PlusHours(17).PlusMinutes(30)).Hour;
            var Midnight = new RomanDateTime(winterDate).Hour;
            var ElevenFiftyNinePM = new RomanDateTime(winterDate.PlusHours(23).PlusMinutes(59)).Hour;
            var OneMinutePastMidnight = new RomanDateTime(winterDate.PlusMinutes(1)).Hour;

            Assert.AreEqual("hora VI", TwelvePM);
            Assert.AreEqual("hora VII", TwelveFifteenPM);
            Assert.AreEqual("hora noctis VII", OneAM);
            Assert.AreEqual("hora II", NineAM);
            Assert.AreEqual("hora noctis II", SevenPM);
            Assert.AreEqual("hora noctis X", FourAM);
            Assert.AreEqual("hora noctis I", FiveThrityPM);
            Assert.AreEqual("hora noctis VII", Midnight);
            Assert.AreEqual("hora noctis VI", ElevenFiftyNinePM);
            Assert.AreEqual("hora noctis VII", OneMinutePastMidnight);
        }

        [TestMethod]
        public void GetTime_ReturnsCorrectEquinoxTimes()
        {
            var equinoxDate = new LocalDateTime(2019, 9, 1, 0, 0);

            var TwelvePM = new RomanDateTime(equinoxDate.PlusHours(12)).Hour;
            var TwelveFifteenPM = new RomanDateTime(equinoxDate.PlusHours(12).PlusMinutes(15)).Hour;
            var OneAM = new RomanDateTime(equinoxDate.PlusHours(1)).Hour;
            var NineAM = new RomanDateTime(equinoxDate.PlusHours(9)).Hour;
            var SevenPM = new RomanDateTime(equinoxDate.PlusHours(19)).Hour;
            var FourAM = new RomanDateTime(equinoxDate.PlusHours(4)).Hour;
            var FiveThrityPM = new RomanDateTime(equinoxDate.PlusHours(17).PlusMinutes(30)).Hour;
            var Midnight = new RomanDateTime(equinoxDate).Hour;
            var ElevenFiftyNinePM = new RomanDateTime(equinoxDate.PlusHours(23).PlusMinutes(59)).Hour;
            var OneMinutePastMidnight = new RomanDateTime(equinoxDate.PlusMinutes(1)).Hour;

            Assert.AreEqual("hora VI", TwelvePM);
            Assert.AreEqual("hora VII", TwelveFifteenPM);
            Assert.AreEqual("hora noctis VII", OneAM);
            Assert.AreEqual("hora III", NineAM);
            Assert.AreEqual("hora noctis I", SevenPM);
            Assert.AreEqual("hora noctis X", FourAM);
            Assert.AreEqual("hora XII", FiveThrityPM);
            Assert.AreEqual("hora noctis VII", Midnight);
            Assert.AreEqual("hora noctis VI", ElevenFiftyNinePM);
            Assert.AreEqual("hora noctis VII", OneMinutePastMidnight);
        }

        [TestMethod]
        public void GetTime_ReturnsCorrectSummerTimes()
        {
            var summerDate = new LocalDateTime(2019, 6, 1, 0, 0);

            var TwelvePM = new RomanDateTime(summerDate.PlusHours(12)).Hour;
            var TwelveFifteenPM = new RomanDateTime(summerDate.PlusHours(12).PlusMinutes(15)).Hour;
            var OneAM = new RomanDateTime(summerDate.PlusHours(1)).Hour;
            var NineAM = new RomanDateTime(summerDate.PlusHours(9)).Hour;
            var SevenPM = new RomanDateTime(summerDate.PlusHours(19)).Hour;
            var FourAM = new RomanDateTime(summerDate.PlusHours(4)).Hour;
            var FiveThrityPM = new RomanDateTime(summerDate.PlusHours(17).PlusMinutes(30)).Hour;
            var Midnight = new RomanDateTime(summerDate).Hour;
            var ElevenFiftyNinePM = new RomanDateTime(summerDate.PlusHours(23).PlusMinutes(59)).Hour;
            var OneMinutePastMidnight = new RomanDateTime(summerDate.PlusMinutes(1)).Hour;

            Assert.AreEqual("hora VI", TwelvePM);
            Assert.AreEqual("hora VII", TwelveFifteenPM);
            Assert.AreEqual("hora noctis VIII", OneAM);
            Assert.AreEqual("hora IV", NineAM);
            Assert.AreEqual("hora XII", SevenPM);
            Assert.AreEqual("hora noctis XII", FourAM);
            Assert.AreEqual("hora XI", FiveThrityPM);
            Assert.AreEqual("hora noctis VII", Midnight);
            Assert.AreEqual("hora noctis VI", ElevenFiftyNinePM);
            Assert.AreEqual("hora noctis VII", OneMinutePastMidnight);
        }

        [TestMethod]
        public void RomanDates_HaveCorrectNundinalLetter()
        {
            var ADate = new RomanDateTime(2018, 1, 8);
            var BDate = new RomanDateTime(2018, 1, 9);
            var CDate = new RomanDateTime(2018, 1, 10);
            var DDate = new RomanDateTime(2018, 1, 11);
            var EDate = new RomanDateTime(2018, 1, 12);
            var FDate = new RomanDateTime(2018, 1, 13);
            var GDate = new RomanDateTime(2018, 1, 14);
            var HDate = new RomanDateTime(2018, 1, 15);

            Assert.AreEqual(NundinalLetters.A, ADate.NundinalLetter);
            Assert.AreEqual(NundinalLetters.B, BDate.NundinalLetter);
            Assert.AreEqual(NundinalLetters.C, CDate.NundinalLetter);
            Assert.AreEqual(NundinalLetters.D, DDate.NundinalLetter);
            Assert.AreEqual(NundinalLetters.E, EDate.NundinalLetter);
            Assert.AreEqual(NundinalLetters.F, FDate.NundinalLetter);
            Assert.AreEqual(NundinalLetters.G, GDate.NundinalLetter);
            Assert.AreEqual(NundinalLetters.H, HDate.NundinalLetter);
        }

        [TestMethod]
        public void ToFormattedString_ReturnsCorrectElements()
        {
            var romanDate = new RomanDateTime(2018, 1, 17);

            var time = romanDate.ToString("t");
            var hour = romanDate.ToString("h");
            var vigila = romanDate.ToString("v");
            var shortPrefix = romanDate.ToString("p");
            var fullPrefix = romanDate.ToString("P");
            var daysUntil = romanDate.ToString("d");
            var shortSetDay = romanDate.ToString("sx");
            var fullSetDay = romanDate.ToString("Sx");
            var shortMonth = romanDate.ToString("m");
            var fullMonth = romanDate.ToString("M");
            var adYear = romanDate.ToString("y");
            var aucYear = romanDate.ToString("Yx");
            var calDay = romanDate.ToString("Dx");
            var nundinal = romanDate.ToString("Dn");
            var shortCalMonth = romanDate.ToString("cx");
            var fullCalMonth = romanDate.ToString("Cx");

            Assert.AreEqual("Vigila Tertia", time);
            Assert.AreEqual("hora noctis VII", hour);
            Assert.AreEqual("Vigila Tertia", vigila);
            Assert.AreEqual("a.d.", shortPrefix);
            Assert.AreEqual("ante diem", fullPrefix);
            Assert.AreEqual("XVI", daysUntil);
            Assert.AreEqual("Kal.", shortSetDay);
            Assert.AreEqual("Kalendas", fullSetDay);
            Assert.AreEqual("Feb.", shortMonth);
            Assert.AreEqual("Februarias", fullMonth);
            Assert.AreEqual("MMXVIII", adYear);
            Assert.AreEqual("MMDCCLXXI", aucYear);
            Assert.AreEqual("XVII", calDay);
            Assert.AreEqual("B", nundinal);
            Assert.AreEqual("Ian.", shortCalMonth);
            Assert.AreEqual("Ianuarius", fullCalMonth);
        }

        [TestMethod]
        public void AddHours_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddHours(1);

            var expected = new RomanDateTime(2019, 1, 1, 13);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddDays_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddDays(1);

            var expected = new RomanDateTime(2019, 1, 2, 12);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddMonths_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddMonths(1);

            var expected = new RomanDateTime(2019, 2, 1, 12);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_AddsToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddYears(1);

            var expected = new RomanDateTime(2020, 1, 1, 12);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void Add_AddsAllToRomanDate()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);
            var newDate = romanDate.AddYears(1).AddMonths(3).AddDays(14).AddHours(-3);

            var expected = new RomanDateTime(2020, 4, 15, 9);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void ToDateTime_ReturnsOriginalDateTime()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);

            var expected = new LocalDateTime(2019, 1, 1, 12, 0);

            Assert.AreEqual(expected, romanDate.ToDateTime());
        }
    }
}

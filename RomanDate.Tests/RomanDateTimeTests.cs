using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanDate.Enums;
using RomanDate.Helpers;

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
        public void RomanDateTime_ReturnsBCDayInRomanCalendar()
        {
            var twentyThirdOfMarch = new RomanDateTime(50, 3, 23, Eras.BC);
            var thirtyFirstOfMarch = new RomanDateTime(110, 3, 31, Eras.BC);
            var twentyFourthOfMarch = new RomanDateTime(216, 3, 24, Eras.BC);
            var twentyFifthOfMarch = new RomanDateTime(45, 3, 25, Eras.BC);

            var twentyThirdOfFebruary = new RomanDateTime(2016, 2, 23, Eras.BC);
            var twentyNinthOfFebruary = new RomanDateTime(1, 2, 29, Eras.BC);
            var twentyFourthOfFebruary = new RomanDateTime(12, 2, 24, Eras.BC);
            var twentyFifthOfFebruary = new RomanDateTime(1, 2, 25, Eras.BC);

            Assert.AreEqual("L BC", twentyThirdOfMarch.ToString("y e"));
            Assert.AreEqual("CX BC", thirtyFirstOfMarch.ToString("y e"));
            Assert.AreEqual("CCXVI BC", twentyFourthOfMarch.ToString("y e"));
            Assert.AreEqual("XLV BC", twentyFifthOfMarch.ToString("y e"));

            Assert.AreEqual("MMXVI BC", twentyThirdOfFebruary.ToString("y e"));
            Assert.AreEqual("I BC", twentyNinthOfFebruary.ToString("y e"));
            Assert.AreEqual("XII BC", twentyFourthOfFebruary.ToString("y e"));
            Assert.AreEqual("I BC", twentyFifthOfFebruary.ToString("y e"));
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
            var absMin = RomanDateTime.AbsoluteMinValue;

            Assert.AreEqual("Kalendis Ianuariis I", $"{min.Day} {min.Year}");
            Assert.AreEqual("pridie Kalendis Ianuariis MMMMMMMMMCMXCIX", $"{max.Day} {max.Year}");
            Assert.AreEqual("pridie Kalendis Ianuariis MMMMMMMMMCMXCIX", $"{absMin.Day} {absMin.Year}");
        }

        [TestMethod]
        public void RomanDateTime_YearConstructorReturnsCorrectDate()
        {
            var roman = new RomanDateTime(2019);

            Assert.AreEqual("Vigila Tertia, Kalendis Ianuariis MMXIX", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_MonthConstructorReturnsCorrectDate()
        {
            var roman = new RomanDateTime(2019, 3);

            Assert.AreEqual("Vigila Tertia, Kalendis Martiis MMXIX", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_DayConstructorReturnsCorrectDate()
        {
            var roman = new RomanDateTime(2019, 4, 7);

            Assert.AreEqual("Vigila Tertia, ante diem VII Idus Apriles MMXIX", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_HourConstructorReturnsCorrectDate()
        {
            var roman = new RomanDateTime(2019, 5, 12, 13);

            Assert.AreEqual("hora VII, ante diem IV Idus Maias MMXIX", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_DateTimeConstructorReturnsCorrectDate()
        {
            var roman = new RomanDateTime(new DateTime(2018, 2, 16, 18, 14, 39));

            Assert.AreEqual("Vigila Prima, ante diem XIV Kalendas Martias MMXVIII", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_YearConstructorReturnsCorrectDateInBCEra()
        {
            var roman = new RomanDateTime(201, Eras.BC);

            Assert.AreEqual("Vigila Tertia, Kalendis Ianuariis CCI BC", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_MonthConstructorReturnsCorrectDateInBCEra()
        {
            var roman = new RomanDateTime(201, 8, Eras.BC);

            Assert.AreEqual("Vigila Tertia, Kalendis Augustis CCI BC", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_DayConstructorReturnsCorrectDateInBCEra()
        {
            var roman = new RomanDateTime(201, 5, 3, Eras.BC);

            Assert.AreEqual("Vigila Tertia, ante diem V Nonas Maias CCI BC", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_HourConstructorReturnsCorrectDateInBCEra()
        {
            var roman = new RomanDateTime(201, 9, 11, 9, Eras.BC);

            Assert.AreEqual("hora III, ante diem III Idus Septembres CCI BC", roman.ToString());
        }

        [TestMethod]
        public void RomanDateTime_DateTimeConstructorReturnsCorrectDateInBCEra()
        {
            var roman = new RomanDateTime(new DateTime(201, 11, 20, 21, 9, 55));

            Assert.AreEqual("Vigila Secunda, ante diem XII Kalendas Decembres CCI BC", roman.ToString());
        }

        [TestMethod]
        public void GetTime_ReturnsCorrectWinterTimes()
        {
            var winterDate = new DateTime(2019, 12, 1);

            var TwelvePM = new RomanDateTime(winterDate.AddHours(12)).Hour;
            var TwelveFifteenPM = new RomanDateTime(winterDate.AddHours(12).AddMinutes(15)).Hour;
            var OneAM = new RomanDateTime(winterDate.AddHours(1)).Hour;
            var NineAM = new RomanDateTime(winterDate.AddHours(9)).Hour;
            var SevenPM = new RomanDateTime(winterDate.AddHours(19)).Hour;
            var FourAM = new RomanDateTime(winterDate.AddHours(4)).Hour;
            var FiveThrityPM = new RomanDateTime(winterDate.AddHours(17).AddMinutes(30)).Hour;
            var Midnight = new RomanDateTime(winterDate).Hour;
            var ElevenFiftyNinePM = new RomanDateTime(winterDate.AddHours(23).AddMinutes(59)).Hour;
            var OneMinutePastMidnight = new RomanDateTime(winterDate.AddMinutes(1)).Hour;

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
            var equinoxDate = new DateTime(2019, 9, 1);

            var TwelvePM = new RomanDateTime(equinoxDate.AddHours(12)).Hour;
            var TwelveFifteenPM = new RomanDateTime(equinoxDate.AddHours(12).AddMinutes(15)).Hour;
            var OneAM = new RomanDateTime(equinoxDate.AddHours(1)).Hour;
            var NineAM = new RomanDateTime(equinoxDate.AddHours(9)).Hour;
            var SevenPM = new RomanDateTime(equinoxDate.AddHours(19)).Hour;
            var FourAM = new RomanDateTime(equinoxDate.AddHours(4)).Hour;
            var FiveThrityPM = new RomanDateTime(equinoxDate.AddHours(17).AddMinutes(30)).Hour;
            var Midnight = new RomanDateTime(equinoxDate).Hour;
            var ElevenFiftyNinePM = new RomanDateTime(equinoxDate.AddHours(23).AddMinutes(59)).Hour;
            var OneMinutePastMidnight = new RomanDateTime(equinoxDate.AddMinutes(1)).Hour;

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
            var summerDate = new DateTime(2019, 6, 1);

            var TwelvePM = new RomanDateTime(summerDate.AddHours(12)).Hour;
            var TwelveFifteenPM = new RomanDateTime(summerDate.AddHours(12).AddMinutes(15)).Hour;
            var OneAM = new RomanDateTime(summerDate.AddHours(1)).Hour;
            var NineAM = new RomanDateTime(summerDate.AddHours(9)).Hour;
            var SevenPM = new RomanDateTime(summerDate.AddHours(19)).Hour;
            var FourAM = new RomanDateTime(summerDate.AddHours(4)).Hour;
            var FiveThrityPM = new RomanDateTime(summerDate.AddHours(17).AddMinutes(30)).Hour;
            var Midnight = new RomanDateTime(summerDate).Hour;
            var ElevenFiftyNinePM = new RomanDateTime(summerDate.AddHours(23).AddMinutes(59)).Hour;
            var OneMinutePastMidnight = new RomanDateTime(summerDate.AddMinutes(1)).Hour;

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
        public void RomanDates_HaveCorrectNundinalLetterInBCEra()
        {
            var ADate = new RomanDateTime(1, 1, 1, Eras.BC);
            var BDate = new RomanDateTime(1, 1, 2, Eras.BC);
            var CDate = new RomanDateTime(1, 1, 3, Eras.BC);
            var DDate = new RomanDateTime(1, 1, 4, Eras.BC);
            var EDate = new RomanDateTime(1, 1, 5, Eras.BC);
            var FDate = new RomanDateTime(1, 1, 6, Eras.BC);
            var GDate = new RomanDateTime(1, 1, 7, Eras.BC);
            var HDate = new RomanDateTime(1, 1, 8, Eras.BC);

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
            var year = romanDate.ToString("y");
            var aucYear = romanDate.ToString("Yx");
            var era = romanDate.ToString("e");
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
            Assert.AreEqual("MMXVIII", year);
            Assert.AreEqual("MMDCCLXXI", aucYear);
            Assert.AreEqual("AD", era);
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
        public void AddHours_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 12, 31, 23, Eras.BC);
            var newDate = romanDate.AddHours(1);

            var expected = new RomanDateTime(1, 1, 1, 0);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddHours_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1, 0);
            var newDate = romanDate.AddHours(-1);

            var expected = new RomanDateTime(1, 12, 31, 23, Eras.BC);

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
        public void AddDays_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 12, 31, Eras.BC);
            var newDate = romanDate.AddDays(1);

            var expected = new RomanDateTime(1, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddDays_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddDays(-1);

            var expected = new RomanDateTime(1, 12, 31, Eras.BC);

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
        public void AddMonths_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 12, 1, Eras.BC);
            var newDate = romanDate.AddMonths(1);

            var expected = new RomanDateTime(1, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddMonths_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddMonths(-1);

            var expected = new RomanDateTime(1, 12, 1, Eras.BC);

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
        public void AddYears_CorrectlyCrossesToADEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1, Eras.BC);
            var newDate = romanDate.AddYears(1);

            var expected = new RomanDateTime(1, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_CorrectlyCrossesToBCEra()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddYears(-1);

            var expected = new RomanDateTime(1, 1, 1, Eras.BC);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_CorrectlyCrossesToADEraMultipleYears()
        {
            var romanDate = new RomanDateTime(1, 1, 1, Eras.BC);
            var newDate = romanDate.AddYears(10);

            var expected = new RomanDateTime(10, 1, 1);

            Assert.AreEqual(expected, newDate);
        }

        [TestMethod]
        public void AddYears_CorrectlyCrossesToBCEraMultipleYears()
        {
            var romanDate = new RomanDateTime(1, 1, 1);
            var newDate = romanDate.AddYears(-10);

            var expected = new RomanDateTime(10, 1, 1, Eras.BC);

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
        public void ToDateTime_ReturnsOriginalDateTimeAD()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12);

            var expected = new DateTime(2019, 1, 1, 12, 0, 0);

            Assert.AreEqual(expected, romanDate.ToDateTime().DateTime);
            Assert.AreEqual(Eras.AD, romanDate.ToDateTime().Era);
        }

        [TestMethod]
        public void ToDateTime_ReturnsOriginalDateTimeBC()
        {
            var romanDate = new RomanDateTime(2019, 1, 1, 12, Eras.BC);

            var expected = new DateTime(2019, 1, 1, 12, 0, 0);

            Assert.AreEqual(expected, romanDate.ToDateTime().DateTime);
            Assert.AreEqual(Eras.BC, romanDate.ToDateTime().Era);
        }
    }
}
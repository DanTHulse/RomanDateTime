using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using RomanDate.Enums;

namespace RomanDate.Tests
{
    [TestClass]
    public partial class RomanDateTimeTests
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
            var roman = new RomanDateTime(new DateTime(201, 11, 20, 21, 9, 55), Eras.BC);

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
        public void RomanDateTime_ReturnsCorrectAUCYear()
        {
            var i1AD = new RomanDateTime(1);
            var i1BC = new RomanDateTime(1, Eras.BC);
            var i2019AD = new RomanDateTime(2019);
            var i753BC = new RomanDateTime(753, Eras.BC);
            var i754BC = new RomanDateTime(754, Eras.BC);

            Assert.AreEqual("DCCLIV", i1AD.AucYear);
            Assert.AreEqual("DCCLIII", i1BC.AucYear);
            Assert.AreEqual("MMDCCLXXII", i2019AD.AucYear);
            Assert.AreEqual("I", i753BC.AucYear);
            Assert.AreEqual("", i754BC.AucYear);
        }

        [TestMethod]
        public void ReturnConsularYear_Consulship_ReturnsCorrectYearString()
        {
            var item = new RomanDateTime(509, Eras.BC);

            Assert.AreEqual("Year of the Consulship of Brutus and Collatinus", item.ConsularYear);
        }

        [Ignore]
        [TestMethod]
        public void ReturnConsularYear_Dictatorship_ReturnsCorrectYearString()
        {
            var item = new RomanDateTime(509, Eras.BC);

            Assert.AreEqual("", item.ConsularYear);
        }

        [Ignore]
        [TestMethod]
        public void ReturnConsularYear_Tribunate_ReturnsCorrectYearString()
        {
            var item = new RomanDateTime(509, Eras.BC);

            Assert.AreEqual("", item.ConsularYear);
        }

        [Ignore]
        [TestMethod]
        public void ReturnConsularYear_Decemviri_ReturnsCorrectYearString()
        {
            var item = new RomanDateTime(509, Eras.BC);

            Assert.AreEqual("", item.ConsularYear);
        }

        [Ignore]
        [TestMethod]
        public void ReturnConsularYear_ReturnsEmptyStringIfNoDataFound()
        {
            var item = new RomanDateTime(508, Eras.BC);

            Assert.AreEqual("", item.ConsularYear);
        }

        [TestMethod]
        public void RomanDateTime_AD_ComparesCorrectly()
        {
            var pastDate = new RomanDateTime(2018, 1, 12);
            var presentDate = new RomanDateTime(2019, 1, 12);
            var futureDate = new RomanDateTime(2020, 1, 12);

            var comparedDate = new RomanDateTime(2019, 1, 12);

            Assert.AreEqual(0, comparedDate.CompareTo(presentDate));
            Assert.AreEqual(-1, comparedDate.CompareTo(futureDate));
            Assert.AreEqual(1, comparedDate.CompareTo(pastDate));
        }

        [TestMethod]
        public void RomanDateTime_BC_ComparesCorrectly()
        {
            var pastDate = new RomanDateTime(202, 1, 12, Eras.BC);
            var presentDate = new RomanDateTime(100, 1, 12, Eras.BC);
            var futureDate = new RomanDateTime(50, 1, 12, Eras.BC);

            var comparedDate = new RomanDateTime(100, 1, 12, Eras.BC);

            Assert.AreEqual(0, comparedDate.CompareTo(presentDate));
            Assert.AreEqual(-1, comparedDate.CompareTo(futureDate));
            Assert.AreEqual(1, comparedDate.CompareTo(pastDate));
        }

        [TestMethod]
        public void RomanDateTime_AD_BC_ComparesCorrectly()
        {
            var pastDate = new RomanDateTime(50, 1, 12, Eras.BC);
            var presentDate = new RomanDateTime(2, 1, 12, Eras.BC);
            var futureDate = new RomanDateTime(50, 1, 12, Eras.AD);

            var comparedDate = new RomanDateTime(2, 1, 12, Eras.BC);

            Assert.AreEqual(0, comparedDate.CompareTo(presentDate));
            Assert.AreEqual(-1, comparedDate.CompareTo(futureDate));
            Assert.AreEqual(1, comparedDate.CompareTo(pastDate));
        }

        [TestMethod]
        public void Conversion_To_DateTime()
        {
            var date = (DateTime)RomanDateTime.Now;

            Assert.AreEqual(DateTime.Now.Date, date.Date);
        }

        [TestMethod]
        public void Conversion_From_DateTime()
        {
            var date = (RomanDateTime)DateTime.Now;

            Assert.AreEqual(RomanDateTime.Now.Date, date.Date);
        }

        [TestMethod]
        public void Conversion_To_LocalDateTime()
        {
            var date = (LocalDateTime)new RomanDateTime(2019, 01, 01);
            var compDate = new LocalDateTime(2019, 01, 01, 12, 12, 12);

            Assert.AreEqual(compDate.Date, date.Date);
        }

        [TestMethod]
        public void Conversion_From_LocalDateTime()
        {
            var date = (RomanDateTime)new LocalDateTime(2019, 01, 01, 12, 12, 12);
            var compDate = new RomanDateTime(2019, 01, 01);

            Assert.AreEqual(compDate.Date, date.Date);
        }
    }
}
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.censusAnalyser;

namespace CensualAnalyserTest
{
    public class Tests
    {
        //Headers
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        //CorrectFilePaths
        static string indianStateCensusFilePath = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCode.csv";
        //WrongFilePaths
        static string wrongIndianStateCodeFilePath = "";
        static string wrongIndianStateCensusFilePath = "";
        //WrongFiles
        static string wrongHeaderIndianStateCodeFile = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\WrongIndiaStateCode.csv";
        static string wrongHeaderIndianStateCensusFile = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCode.txt";
        static string wrongIndianStateCensusFileType = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCensusData.txt";
        //WrongDelimiter
        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\DelimiterIndiaStateCensusData.csv";
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\91708\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\DelimiterIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //Count
        //TC 1.1
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        //TC 2.1
        [Test]
        public void GivenIndianCodeFilePath_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //WrongFilePath
        //TC 1.2
        [Test]
        public void GivenWrongIndianCensusCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        //TC 2.2
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        //WrongFileType
        //TC 1.3
        [Test]
        public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        //TC 2.3 
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.eType);
        }

        //FileWithWrongDelimeter
        //TC 1.4
        [Test]
        public void GivenWrongIndianCensusDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        //TC 2.4
        [Test]
        public void GivenWrongIndianStateCodeDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.eType);
        }

        //WrongHeader
        //TC 1.5
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianStateCensusFile, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        //TC 2.5
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianStateCodeFile, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.eType);
        }
    }
}
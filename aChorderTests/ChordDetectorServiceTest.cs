using aChorder.Models;
using aChorder.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aChorderTests
{
    [TestClass]
    public class ChordDetectorServiceTest
    {
        private IChordDetectorService _chordDetectorService;
        public ChordDetectorServiceTest()
        {
            _chordDetectorService = new ChordDetectorService(@"..\..\..\..\aChorder\\wwwroot\\Chords");
        }

        [TestMethod]
        public void CutIntoLines()
        {            
            //Arrange
            //Act
            List<string> a1 = _chordDetectorService.CutIntoLines("aa\r\nbb\r\ncc").ToList();
            List<string> a2 = _chordDetectorService.CutIntoLines("a d s a\r\nbb\r\ncc").ToList();
            List<string> a3 = _chordDetectorService.CutIntoLines("Am A B\r\nJestem Twoim Przeznaczeniem\r\nC C C\r\nO tak mala").ToList();
            //Assert
            CollectionAssert.AreEqual(a1, new List<string> { "aa", "bb", "cc" });
            CollectionAssert.AreEqual(a2, new List<string> { "a d s a", "bb", "cc" });
            CollectionAssert.AreEqual(a3, new List<string> { "Am A B", "Jestem Twoim Przeznaczeniem", "C C C", "O tak mala" });

        }

        [TestMethod]
        public void ExtractTopChords_1()
        {
            //Arrange
            List<string> expectedChords = new List<string>() { "Am","A","B","C"};
            //Act
            List<string> detectedChords = _chordDetectorService.ExtractTopChords("Am A B\r\nJestem Twoim Przeznaczeniem\r\nC C C\r\nO tak mala").ToList();
            //Assert
            CollectionAssert.AreEquivalent(detectedChords,expectedChords);
        }

        [TestMethod]
        public void ExtractTopChords_2()
        {
            //Arrange
            List<string> expectedChords = new List<string>() { "C#", "D#", "F#"};
            //Act
            List<string> detectedChords = _chordDetectorService.ExtractTopChords("C# D#\r\nJestem Twoim Przeznaczeniem\r\nF#\r\nO tak mala").ToList();
            //Assert
            CollectionAssert.AreEquivalent(detectedChords, expectedChords);
        }

    }
}

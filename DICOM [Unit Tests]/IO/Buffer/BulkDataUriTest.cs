using System;
using Xunit;
using System.IO;
using System.Linq;
using Dicom.IO.Buffer;

namespace DICOM__Unit_Tests_
{
	public class BulkDataUriTest
	{
		[Fact]
		public void TestReadBulkData()
		{
			var path = Path.GetFullPath("test.txt");
			var bulkData = new BulkUriByteBuffer("file:" + path);

			Assert.Throws<InvalidOperationException>(() => bulkData.Data);
			Assert.Throws<InvalidOperationException>(() => bulkData.Size);

			bulkData.GetData();

			byte[] expected = File.ReadAllBytes("test.txt");

			Assert.True(bulkData.Data.SequenceEqual(expected));
			Assert.Equal(bulkData.Size, (uint)expected.Length);
		}
	}
}

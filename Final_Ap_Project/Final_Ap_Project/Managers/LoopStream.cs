using NAudio.Wave;

namespace Final_Ap_Project.Managers
{
    /// <summary>
    /// Plays a WaveStream continuously by restarting it
    /// when it reaches the end.
    /// </summary>
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;

        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
        }

        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        public override long Length
        {
            get { return sourceStream.Length; }
        }

        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);

                if (bytesRead == 0)
                {
                    sourceStream.Position = 0;
                    bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);

                    if (bytesRead == 0)
                        break;
                }

                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }
    }
}
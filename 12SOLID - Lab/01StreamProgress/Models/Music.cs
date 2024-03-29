﻿namespace StreamProgress.Models
{
    using Interfaces;
    public class Music : IFile
    {
        private string artist;
        private string album;
        public Music(string artist,string album,int length,int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length=length;
            this.BytesSent=bytesSent;
        }
        public int Length { get;private set; }

        public int BytesSent { get; private set; }
    }
}

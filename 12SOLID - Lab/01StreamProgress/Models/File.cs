﻿namespace StreamProgress.Models
{
    using Interfaces;
    public class File : IFile
    {
        private string name;
        public File(string name,int length,int bytesSent)
        {
            this.name = name;
            this.Length=length;
            this.BytesSent=bytesSent;
        }
        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
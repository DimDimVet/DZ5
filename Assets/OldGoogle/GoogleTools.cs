using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityGoogleDrive;
using UnityGoogleDrive.Data;
using System.Text;

public static class GoogleTools
{
    public static string NameFile = "DataDZ4.json";
    public static List<File> GetListFile()//�������� �� ��������� ���� ������������ ������
    {
        List<File> getList = new List<File>();
        GoogleDriveFiles.List().Send().OnDone += fileList =>
         {
             getList = fileList.Files;
         };
       return getList;
    }

    public static File SaveFile(string data)//������� ���� � �������� ��������
    {
        File file = new File {Name= $"{NameFile}", Content=Encoding.ASCII.GetBytes(data) };
        GoogleDriveFiles.Create(file).Send();
        return file;
    }

    public static string LoadFile(string idFile)//������� ���� � �������� �������� �� id �� �����
    {
        File getFile = new File();
        GoogleDriveFiles.Download(idFile).Send().OnDone += file =>
         {
             getFile = file;
         };
        string str = Encoding.ASCII.GetString(getFile.Content, 0, getFile.Content.Length);
        return str;
        
    }
}

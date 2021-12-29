namespace System.IO;

/// <summary>
/// using var tmp = TempFile.Create(); <br />
/// using var tmp = TempFile.Extension("*.png"); <br />
/// </summary>
internal sealed class TempFile : IDisposable
{
    #region Path
    string path;

    public string Path
    {
        get
        {
            if (path == null)
                throw new ObjectDisposedException(GetType().Name);

            return path;
        }
    }
    #endregion

    #region Create()
    public static TempFile Create()
    {
        return new TempFile();
    }

    public static TempFile Extension(string extension)
    {
        var tempFile = System.IO.Path.GetTempFileName();
        var tempFile2 = System.IO.Path.ChangeExtension(tempFile, extension);
        File.Move(tempFile, tempFile2, true);
        return new(tempFile2);
    }

    private TempFile() : this(System.IO.Path.GetTempFileName()) { }

    private TempFile(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException("path");

        this.path = path;
    }
    #endregion

    #region Dispose()
    ~TempFile() => Dispose(false);

    public void Dispose() => Dispose(true);

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            GC.SuppressFinalize(this);
        }

        if (path != null)
        {
            try { File.Delete(path); }
            catch { } // best effort
            path = null;
        }
    }
    #endregion
}
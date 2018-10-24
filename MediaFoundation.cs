/*
 *  Copyright © 2015 devMash.com
 * 
 *  Permission is hereby granted, free of charge, to any person obtaining a copy of this
 *  software and associated documentation files (the “Software”), to deal in the Software
 *  without restriction, including without limitation the rights to use, copy, modify, merge,
 *  publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 *  to whom the Software is furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in all copies or
 *  substantial portions of the Software.
 *  
 * THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 * 
 */

/****************************************************************************************
 *  If you found this example project useful, please feel free to link to the original  *
 *  article on http://www.devmash.com.                                                  *
 ****************************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace GetDuration
{

    /// <summary>
    /// MFAttributesMatchType (MF_ATTRIBUTES_MATCH_TYPE)
    /// </summary>
    ///
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms703793%28v=vs.85%29.aspx
    /// 
    public enum MFAttributesMatchType
    {
        OUR_ITEMS = 0,
        THEIR_ITEMS = 1,
        ALL_ITEMS = 2,
        INTERSECTION = 3,
        SMALLER = 4
    }


    /// <summary>
    /// MFAttributeType (MF_ATTRIBUTE_TYPE)
    /// </summary>
    ///
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms694854%28v=vs.85%29.aspx
    ///
    public enum MFAttributeType
    {
        UINT32 = 0x13,  // VT_UI4
        UINT64 = 0x15,  // VT_UI8
        DOUBLE = 5,     // VT_R8
        GUID = 0x48,    // VT_CLSID
        STRING = 0x1f,  // VT_LPWSTR
        BLOB = 0x1011,  // VT_VECTOR | VT_UI1
        IUNKNOWN = 13   // VT_UNKNOWN
    }


    /// <summary>
    /// MFStartupFlags (see: mpapi.h)
    /// </summary>
    ///
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms702238%28v=vs.85%29.aspx
    /// 
    public enum MFStartupFlags
    {
        Full = 0,
        Lite = 1,
        NoSocket = 1
    }


    /// <summary>
    /// IMFAttributes
    /// </summary>
    /// 
    [ComImport, Guid("2CD2D921-C447-44A7-A13C-4ADABFC247E3"), ComConversionLoss, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMFAttributes
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItem(ref Guid guidKey, [In, Out] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItemType(ref Guid guidKey, out MFAttributeType pType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CompareItem(ref Guid guidKey, ref PropVariant Value, out int pbResult);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Compare([MarshalAs(UnmanagedType.Interface)] IMFAttributes pTheirs, MFAttributesMatchType MatchType, out int pbResult);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUINT32(ref Guid guidKey, out uint punValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUINT64(ref Guid guidKey, out ulong punValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDouble(ref Guid guidKey, out double pfValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetGuid(ref Guid guidKey, out Guid pguidValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStringLength(ref Guid guidKey, out uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetString(ref Guid guidKey, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszValue, uint cchBufSize, [In, Out] ref uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAllocatedString(ref Guid guidKey, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszValue, out uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBlobSize(ref Guid guidKey, out uint pcbBlobSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBlob(ref Guid guidKey, out byte pBuf, uint cbBufSize, [In, Out] ref uint pcbBlobSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAllocatedBlob(ref Guid guidKey, [Out] IntPtr ppBuf, out uint pcbSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUnknown(ref Guid guidKey, ref Guid riid, out IntPtr ppv);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetItem(ref Guid guidKey, ref PropVariant Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteItem(ref Guid guidKey);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteAllItems();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUINT32(ref Guid guidKey, uint unValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUINT64(ref Guid guidKey, ulong unValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDouble(ref Guid guidKey, double fValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetGUID(ref Guid guidKey, ref Guid guidValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetString(ref Guid guidKey, [In, MarshalAs(UnmanagedType.LPWStr)] string wszValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetBlob(ref Guid guidKey, [In] ref byte pBuf, uint cbBufSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUnknown(ref Guid guidKey, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LockStore();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnlockStore();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCount(out uint pcItems);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItemByIndex(uint unIndex, out Guid pguidKey, [In, Out] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyAllItems([In, MarshalAs(UnmanagedType.Interface)] IMFAttributes pDest);
    }


    /// <summary>
    /// IMFMediaBuffer
    /// </summary>
    /// 
    [ComImport, Guid("045FA593-8799-42B8-BC8D-8968C6453507"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss]
    public interface IMFMediaBuffer
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Lock([Out] IntPtr ppbBuffer, out uint pcbMaxLength, out uint pcbCurrentLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Unlock();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCurrentLength(out uint pcbCurrentLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetCurrentLength([In] uint cbCurrentLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMaxLength(out uint pcbMaxLength);
    }


    /// <summary>
    /// IMFMediaType
    /// </summary>
    /// 
    [ComImport, Guid("44AE0FA8-EA31-4109-8D2E-4CAE4997C555"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMFMediaType : IMFAttributes
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItem(ref Guid guidKey, [In, Out] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItemType(ref Guid guidKey, out MFAttributeType pType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CompareItem(ref Guid guidKey, ref PropVariant Value, out int pbResult);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Compare([MarshalAs(UnmanagedType.Interface)] IMFAttributes pTheirs, MFAttributesMatchType MatchType, out int pbResult);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUINT32(ref Guid guidKey, out uint punValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUINT64(ref Guid guidKey, out ulong punValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDouble(ref Guid guidKey, out double pfValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetGuid(ref Guid guidKey, out Guid pguidValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStringLength(ref Guid guidKey, out uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetString(ref Guid guidKey, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszValue, uint cchBufSize, [In, Out] ref uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAllocatedString(ref Guid guidKey, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszValue, out uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBlobSize(ref Guid guidKey, out uint pcbBlobSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBlob(ref Guid guidKey, out byte pBuf, uint cbBufSize, [In, Out] ref uint pcbBlobSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAllocatedBlob(ref Guid guidKey, [Out] IntPtr ppBuf, out uint pcbSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUnknown(ref Guid guidKey, ref Guid riid, out IntPtr ppv);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetItem(ref Guid guidKey, ref PropVariant Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteItem(ref Guid guidKey);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteAllItems();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUINT32(ref Guid guidKey, uint unValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUINT64(ref Guid guidKey, ulong unValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDouble(ref Guid guidKey, double fValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetGUID(ref Guid guidKey, ref Guid guidValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetString(ref Guid guidKey, [In, MarshalAs(UnmanagedType.LPWStr)] string wszValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetBlob(ref Guid guidKey, [In] ref byte pBuf, uint cbBufSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUnknown(ref Guid guidKey, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LockStore();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnlockStore();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCount(out uint pcItems);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItemByIndex(uint unIndex, out Guid pguidKey, [In, Out] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyAllItems([In, MarshalAs(UnmanagedType.Interface)] IMFAttributes pDest);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMajorType(out Guid pguidMajorType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsCompressedFormat(out int pfCompressed);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsEqual([In, MarshalAs(UnmanagedType.Interface)] IMFMediaType pIMediaType, out uint pdwFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRepresentation([In] Guid guidRepresentation, out IntPtr ppvRepresentation);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void FreeRepresentation([In] Guid guidRepresentation, [In] IntPtr pvRepresentation);
    }


    /// <summary>
    /// IMFSample
    /// </summary>
    /// 
    [ComImport, Guid("C40A00F2-B93A-4D80-AE8C-5A1C634F58E4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMFSample : IMFAttributes
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItem(ref Guid guidKey, [In, Out] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItemType(ref Guid guidKey, out MFAttributeType pType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CompareItem(ref Guid guidKey, ref PropVariant Value, out int pbResult);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Compare([MarshalAs(UnmanagedType.Interface)] IMFAttributes pTheirs, MFAttributesMatchType MatchType, out int pbResult);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUINT32(ref Guid guidKey, out uint punValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUINT64(ref Guid guidKey, out ulong punValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDouble(ref Guid guidKey, out double pfValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetGuid(ref Guid guidKey, out Guid pguidValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStringLength(ref Guid guidKey, out uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetString(ref Guid guidKey, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszValue, uint cchBufSize, [In, Out] ref uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAllocatedString(ref Guid guidKey, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszValue, out uint pcchLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBlobSize(ref Guid guidKey, out uint pcbBlobSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBlob(ref Guid guidKey, out byte pBuf, uint cbBufSize, [In, Out] ref uint pcbBlobSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAllocatedBlob(ref Guid guidKey, [Out] IntPtr ppBuf, out uint pcbSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUnknown(ref Guid guidKey, ref Guid riid, out IntPtr ppv);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetItem(ref Guid guidKey, ref PropVariant Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteItem(ref Guid guidKey);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DeleteAllItems();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUINT32(ref Guid guidKey, uint unValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUINT64(ref Guid guidKey, ulong unValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDouble(ref Guid guidKey, double fValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetGUID(ref Guid guidKey, ref Guid guidValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetString(ref Guid guidKey, [In, MarshalAs(UnmanagedType.LPWStr)] string wszValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetBlob(ref Guid guidKey, [In] ref byte pBuf, uint cbBufSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUnknown(ref Guid guidKey, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnknown);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LockStore();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnlockStore();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCount(out uint pcItems);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItemByIndex(uint unIndex, out Guid pguidKey, [In, Out] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyAllItems([In, MarshalAs(UnmanagedType.Interface)] IMFAttributes pDest);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSampleFlags(out uint pdwSampleFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetSampleFlags([In] uint dwSampleFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSampleTime(out long phnsSampleTime);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetSampleTime([In] long hnsSampleTime);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSampleDuration(out long phnsSampleDuration);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetSampleDuration([In] long hnsSampleDuration);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBufferCount(out uint pdwBufferCount);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBufferByIndex([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out IMFMediaBuffer ppBuffer);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ConvertToContiguousBuffer([MarshalAs(UnmanagedType.Interface)] out IMFMediaBuffer ppBuffer);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddBuffer([In, MarshalAs(UnmanagedType.Interface)] IMFMediaBuffer pBuffer);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveBufferByIndex([In] uint dwIndex);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveAllBuffers();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetTotalLength(out uint pcbTotalLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CopyToBuffer([In, MarshalAs(UnmanagedType.Interface)] IMFMediaBuffer pBuffer);
    }

 
    /// <summary>
    /// IMFSourceReader
    /// </summary>
    /// 
    [ComImport, Guid("70AE66F2-C809-4E4F-8915-BDCB406B7993"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMFSourceReader
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStreamSelection([In] uint dwStreamIndex, out int pfSelected);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetStreamSelection([In] uint dwStreamIndex, [In] int fSelected);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetNativeMediaType([In] uint dwStreamIndex, [In] uint dwMediaTypeIndex, [MarshalAs(UnmanagedType.Interface)] out IMFMediaType ppMediaType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCurrentMediaType([In] uint dwStreamIndex, [MarshalAs(UnmanagedType.Interface)] out IMFMediaType ppMediaType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetCurrentMediaType([In] uint dwStreamIndex, [In, Out] ref uint pdwReserved, [In, MarshalAs(UnmanagedType.Interface)] IMFMediaType pMediaType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetCurrentPosition([In] ref Guid guidTimeFormat, [In] ref PropVariant varPosition);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ReadSample([In] uint dwStreamIndex, [In] uint dwControlFlags, out uint pdwActualStreamIndex, out uint pdwStreamFlags, out long pllTimestamp, [MarshalAs(UnmanagedType.Interface)] out IMFSample ppSample);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Flush([In] uint dwStreamIndex);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetServiceForStream([In] uint dwStreamIndex, [In] ref Guid guidService, [In] ref Guid riid, out IntPtr ppvObject);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPresentationAttribute([In] uint dwStreamIndex, [In] ref Guid guidAttribute, out PropVariant pvarAttribute);
    }


    /// <summary>
    /// MFInterop
    /// </summary>
    ///
    public static class MFInterop
    {

        [DllImport("mfreadwrite.dll", ExactSpelling = true), SuppressUnmanagedCodeSecurity]
        public static extern int MFCreateSourceReaderFromURL
        (
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
            IMFAttributes pAttributes,
            out IMFSourceReader ppSourceReader
        );

        [DllImport("mfplat.dll", ExactSpelling = true), SuppressUnmanagedCodeSecurity]
        public static extern int MFShutdown();

        [DllImport("mfplat.dll", ExactSpelling = true), SuppressUnmanagedCodeSecurity]
        private static extern int MFStartup
        (
            int Version,
            MFStartupFlags dwFlags
        );

        public static int MFStartup(MFStartupFlags objFlags)
        {
            int MF_VERSION = 0x20070;
            return MFInterop.MFStartup(MF_VERSION, objFlags);
        }

    }

}

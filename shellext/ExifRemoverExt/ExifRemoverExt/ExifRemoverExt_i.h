

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.00.0595 */
/* at Wed Dec 11 06:53:19 2019
 */
/* Compiler settings for ExifRemoverExt.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 8.00.0595 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __ExifRemoverExt_i_h__
#define __ExifRemoverExt_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IExifRemoverShellExt_FWD_DEFINED__
#define __IExifRemoverShellExt_FWD_DEFINED__
typedef interface IExifRemoverShellExt IExifRemoverShellExt;

#endif 	/* __IExifRemoverShellExt_FWD_DEFINED__ */


#ifndef __ExifRemoverShellExt_FWD_DEFINED__
#define __ExifRemoverShellExt_FWD_DEFINED__

#ifdef __cplusplus
typedef class ExifRemoverShellExt ExifRemoverShellExt;
#else
typedef struct ExifRemoverShellExt ExifRemoverShellExt;
#endif /* __cplusplus */

#endif 	/* __ExifRemoverShellExt_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IExifRemoverShellExt_INTERFACE_DEFINED__
#define __IExifRemoverShellExt_INTERFACE_DEFINED__

/* interface IExifRemoverShellExt */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IExifRemoverShellExt;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D113B12E-EEDF-4536-AF27-D173AB7E1E15")
    IExifRemoverShellExt : public IUnknown
    {
    public:
    };
    
    
#else 	/* C style interface */

    typedef struct IExifRemoverShellExtVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IExifRemoverShellExt * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IExifRemoverShellExt * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IExifRemoverShellExt * This);
        
        END_INTERFACE
    } IExifRemoverShellExtVtbl;

    interface IExifRemoverShellExt
    {
        CONST_VTBL struct IExifRemoverShellExtVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IExifRemoverShellExt_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IExifRemoverShellExt_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IExifRemoverShellExt_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IExifRemoverShellExt_INTERFACE_DEFINED__ */



#ifndef __ExifRemoverExtLib_LIBRARY_DEFINED__
#define __ExifRemoverExtLib_LIBRARY_DEFINED__

/* library ExifRemoverExtLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_ExifRemoverExtLib;

EXTERN_C const CLSID CLSID_ExifRemoverShellExt;

#ifdef __cplusplus

class DECLSPEC_UUID("B79D2F2C-42F6-48E3-9FBE-0E2C76CC4422")
ExifRemoverShellExt;
#endif
#endif /* __ExifRemoverExtLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif



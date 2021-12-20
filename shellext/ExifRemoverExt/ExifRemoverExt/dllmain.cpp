// dllmain.cpp : Implementation of DllMain.

#include "stdafx.h"
#include "Resource.h"
#include "ExifRemoverExt_i.h"
#include "dllmain.h"

CExifRemoverExtModule _AtlModule;

// DLL Entry Point
extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
	return _AtlModule.DllMain(dwReason, lpReserved); 
}

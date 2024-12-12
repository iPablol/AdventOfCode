﻿using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    internal class Day12() : Problem("RRRRIICCFF\r\nRRRRIICCCF\r\nVVRRRCCFFF\r\nVVRCCCJFFF\r\nVVVVCJJCFE\r\nVVIVCCJJEE\r\nVVIIICJJEE\r\nMIIIIIJJEE\r\nMIIISIJEEE\r\nMMMISSJEEE",
        "GGGGGDDDDSSSEEEEEEEEEEEEEEEUFFOOOOOOOYYKKKKXKKKKKKKKKKKKKNVVVVVVVVVVVVVVVVVVVYYEEZNNNNNNNNNNBNSSNNNWUUUUUUKKKKKKKKKKKKKKKKKKKKHHHHHHHHHHHHHH\r\nGGDDDDDDDSSSSEEEEEEEEEEEEEEFFFOOOOOOOYYKKKKKKKKKKKKKKKKKNNNVVVVVVVVVVVVVVVVEYYEEENNNNNNNNNNNNNSNNNWWWWWUUIITTKKKKKKKKKKKKKKKKHHHHHHHHHHHHHHH\r\nGGGDDDDDDSSSEEEEEEEEEEEEEFFFFFOKOOOOOOOOKOKKKKKKKKKKKKKKKNNVVVVVVFVVVVVVVVVEEEEEENENNNNNNNNNNNNNNNWWWWWUUTTTTTTKKKKKKKKKKKKKKKHHHHHHHHHHHHHH\r\nGGGGDDDDSSSSESEEEEEEEEEEEEEFFFOOOOOOOOOOKKKKKKKKKKKKKKKKNNNVVVVVVFFFVVVVEEEEEEEEEEEENNNNNNNNNNNNNWWWWWUUUUTTTTTKKKKKKKKKKKKKKKKHHHHHHHHHHHHH\r\nGGGDDDDDTSSSSSSESSEEEEEEEEEFFFFOOOOOOOOOKKKKKKKKKKKKKKKKNNNVVVVVVFFFVVVVEEEEEEEEEEBBBNNNNNNNNNNNWWWWUUUUUTTTTTTTTKKKKKKKKKKKKKKHNHHHHHHHHHHH\r\nGGGBDDDDTSSSSSSSSSSEEEEECFFFFFONOOOOOOOOOOKKKKKKKKKKKKNNNNVVVVVVVFFFVVVVEEEEEEEEEEBBBBBBNNNNNNNNWWWXUUUUUTTTGTTTTTTTKKKKKKKKKKKHNHHHHHHHHHHH\r\nGBBBDDDDSSSSSSSSSSSJEEELFFFFFFOOOOOOOOOOOOKKKSKKKKKKKKKNNNNVVVVVVVVVVVVEEEEEEEEEEBBBBBBNNNNNNNWWWWWFFFFFFFFFFFFFFFTKKKKKKKKKKKHHNHHHHHHHHHHH\r\nGGBBBBBUUUUUUUSSSSSSSLLLFFLFFFOOOOOOOOOOOOKKKKKKKKKKKNNNNNNMMMMVVVVVVVVEEEEEEEEEEBBBBBBBNNNNNNWWWXXFFFFFFFFFFFFFFFFFFFFFFFFKKKHHHHHHHHHHHHHN\r\nBBBBBUUUUUUUUUUSSSSSLLLLLLLFFLOOOOOOOOOOOOKRKKRRKKKKKKKNMMMMMVVVVVVVVVVVEEVVEEEEEBBBBBBBNNNNNXXXXXXFFFFFFFFFFFFFFFFFFFFFFFFKKKHHHZZVHHHHXHHN\r\nBBBBBUUUUUUUUUUAAAAALLLAAAAAAALOOOOOOOOOOOORRRRRRKKKKKQMMMMMMMVMMVGGVVVVVVVVEEEEEBBBBBBNNNUNNXXXXJXFFFFFFFFFFFFFFFFFFFFFFFFKKKHHHZZVFFHHHHNN\r\nBBBBBUUUUUUUUUUAAAAAAAAAAAAAAAZOOOOOOOAOOOOAARRRRRKKRRRMMMMMMMMMMGGGGGVVVVVVEEUEEBBBUUNNNNUUXXXXXXXFFFFFFFFFFFFFFFFFFFFFFFFKKKKKZZVVVVVEHVNN\r\nBBBBBUUUUUUUUUUUAAAAAAAAAAAAAAJJJJOOAAAAAORAARRRRRRRRRMMMMMMMMMMMGGGGGVGGGGEREEWESSUUUUUUUUXXXXXXXXFFFFFFFFFFFFFFFFFFFFFFFFKKKKKKZZVVVVVVVNN\r\nBBBBBUUUUUUUUUUUAAAAAAAAAAAAAAJJJOOOAAAAAAAAARRRRRRRRRMMMMMMMMMMMGGGGGGGGGEEEEWWWUUUUUUUUUUXXXXXXXXXXXXXVFFFFFFFFFFFFFFFFFFQQQKKKVVVVVVVVVVV\r\nBBBBBUUUUUUUUUUUUUUAAAAAAAAAAAZZIDAAAAAAAAAAAAAARRRRRRRFMMMMMMMMMGGGGGGGGGGGFEWWWUUUUUUUUUUXXXXXXXXXXXXZZFFFFFFFFFFFFFFFFFFSQQKQQVVVVVVVVVVV\r\nKKKBBUUUUUUUUUUUUUUAAAAAAAAAAAIIIDAAAAAAAAAAAAAAARRRRRFFMFMMMMMMMGGGGGGGGGEGGWWWWUUUUUUUUXXXXXXXXXXXXAZZZFFFFFFFFFFFFFFFFFFSQQKQQQQVVVVVVVVV\r\nKKBBBUUUUUUUUUUUUUUAAAAAAAAAAAIIAAAAAAAAAAAAAAAAAARRRRFFFFFMFFMMNGGGGGGHEEEEWWWWUUUUUUUXXXXXXXXXXXXXXAZZZFFFFFFFFFKKKKSSCSSSQQQQVVVVVVVVVVVV\r\nKKBBKKKKSUUUUUUUUUUAAAAAAAAZZZIIIIAAAAAAAAAAAAAAAARRRRFFFFFFFFFFGGGGGGGHEEEEEWWWUUUUTUUXXXXXXXXXXXXXXZZZZZZZZZOKKKKKSSSSSSSSSSVVVVVVVVVVVVVV\r\nKKKKKKKKSUUUUUUUAAAAAAAAAAAZZZIIIIAAAAAAAAAAAAAAAARRRFFFFFFFFFFFFGGGGGGEEEEEEWTTYYTTTDUXXXXXXXXXXXXXXEZAAAAAAAAAKSSKSSSSSSSSSSXVVVVVVVVVVVVV\r\nKKKKKKKKKUUUUUUUIEIAAAAAAAZZZZIIIIKIAAAAAAAAAAAAAARRRFFFFFFFFFFFRGGGGRREEEEEEWTTTTTTTTUXXXXXXXXXXXXXIIZAAAAAAAAAGSSSSSSSSSSSSSXXVVVVVVDVVVVV\r\nKKKKKKKKKUUUUUUUIEIEZZZZZZZZZZZIIIIIAAAAAAAAAAAARRRRRFFEFFFFFFFFRGGGGRRRRRRRWWTTTTTTTGGGGGXXGXXXXGXAAAAAAAAAAAAASSSSSSSSSSSSSXXVVVVVVVDVVVVV\r\nKKKKKKKKKUUUUUUUEEIYZZZZZZZZZZGWOIUAAAAAAAAABBAARRRRZTTFFFFFZFRRRRRRRRRRRRRRRTTTTTTTTTTGGGGGGXXXXGGAAAAAAAAAAAAAGSSSSSSSSSSSXXXVVVVVDVDDVVVV\r\nKKKKKKKKKEEEEEEEEEIYYYYTTGWWWZWWIIUUAXAAAAAAYYYYRRRRZZZZZZZZZFRRTTTTTRRRRRRRRRTTTTTTTTGGGGGGXXXGGGGAAAAAAAAAAAAAGSSSSSSSSSSSXXXXXVVVDDDDDDVV\r\nKKKKKKKKKEEEEEEEEEEYYYYTGGWHWZWWWIUHHXAAAAAAYYYYYRRZZZZZZZZZZZRRRTRRRRVRRRVVTTTTTTTTTTTGGGBBBBBGGGGAAAAAAAAAAAAAGGSSSSSSSSSXXXXXVVVDDDDDDDVV\r\nKKKKKKKKKEEEEEEEEEEYGVGTGGHHHWWHIIUHHHYYYYAYYYYBBZZZZZZZZZZZZZZRRRRRRRVVVRVVAATTTTTTTTTTTBBBBBBBBGGAAAAAAAAYGGGGGGWGSPPPPPSXXXXXXVDXDDDDDDVV\r\nKKKKKKKKKEEEEEEGGGGGGGGGGGHHHHWHHHHHHHHYYYAYYYYBZZZZZZZZZZZZZZRRRRRRRRVVVVVVAATTTTTTTTTTHBBBBBBYGGGAAAAAAAAGGGGGGGGGGPPPPPPPXXXXXXDDDDDDDDDV\r\nKKKKKYYKKEEEEEGGGGGGGGGGGGHHHHHHHHHHHHHYYYYYYYZZZZZZZZZZZZZZZZZRRRRRRVVVVVVVVAATTTTTTTTHHBBBBBYYYYYAAAAAAAAGYGGGGGGGGPPPPPPPPXXXXXXDDDDDDDDD\r\nKKKYYYYKKKEEEEGGGGGGGGGGGGHHHHHHHHHHHHPYYJYYYYYYZZZZZZZZZZZZZZZRRRRRRVVVVVVVVVAATTTTTTTTBBBBBUUYYYYYYYAAAAAYYGGGGGGPPPPPPPPPXXXXDDDDDDDDDDDM\r\nKKFFYYYEEEETEGGGMMMMMMMGGGHHNNHHHHHHHHPPPJYJJJJJJGGZZZZZZZZSSSRRRRRVVVVVVVVVCCVTTTTTTTTTTUBUUUUYGYAYYYAAAAAPYGGGGGGPPPPPPOPPXXXXDDDDDDDDDDDD\r\nYFFFYQYYYYEEEEGGMMMMMMMGGGGNNNNNNNNHHHPJJJJJJJJJJJGZZZZZZZZSSRRRRRRRRHVVVVVVVCVTTTJTTTTTUUUUUAAAAAAAAAAAAAAGGGGGPGPPPPPOOOPXXXXXDDDDDDDDDDDD\r\nYYYYYYYYYYEEEYLLMMMMMMMGGGGNNNNNNNNHPPPJJJJJJJJJJJJZZZIZZZZRSRRRHHRHHHVVVVVVVVVTTVVTUUUTUUUUUAAAAAAAAAAYYYBGGGGGPPPPPPPOOOOOOXOOODDDDDDDDDDZ\r\nYYYYYYYYYYYYYYYLMMMMMMMGGGGNNNNNNNNNPPPJJJJJJJJJJIIIIIIIZZRRSRRHHHHHHHHVHVVVIIVVVVVVUUUUUUUUUAAAAAAAAAAAYBBGGGGPPPPPPPOOOOOOOOOOOODDDDDDZZDZ\r\nYYYYYYYYYYYYYYYGMMMMMMMGGGNNNNNNNNRSRPPPPJJJJJJJJIIIIIIIZRRRRRHBBHHHHHHHHHHVVVVVVVNUUUUUUUUUUAAAAAAAAAAAAAAGGGPPPPPPPPPPOOOOOOOOOOOODZZDZZZZ\r\nYYYYYYYYYYYYYYYGMMMMMMMGGGNNNNNNNNRRRRRRJJJJJJJJJIIIIIIZPRPHHHHHHHHHHHHHHJJVVVVVVVNUUUUUUUUUOAAAAAAAAAAAAAAAGGPPPPPPPPOOOOOOOOOOOOOOOOZZZZZZ\r\nYYYYYYYYYYYYYYYXMMMMMMMGGGGGNNNNNRRRRRRRRJJJJJJJJIIIIIIZPPPHHHHHHHHHHHHHHHHVVVVVVVNUUUUUUUUUOOJOOOAAAAAAAAAAGPPPPPPPPPOOOOOOOOOOOOOOOOZZZZZZ\r\nYYYYYYYYYYYYYYYYMMMMMMMGGGNNNNNNNNRRRRRRRRRJJJJJJIIIIZZZZZPHHHHHHHHHHHHHHHHHVVVVVVNUUUUUUUUUOOOOOOAAAAAAAAAAAPPPPPPPPPPPPOOOOOOOOOOOOOOZSSZZ\r\nYYYYYFYYYYYYYYYYMMMMMMMNGNNNNNNNNNRRRRRRRRRHJJJRJIIIIIZZZZZHHHHHHHHHHHHHHHHVVVVVVNNUUUUUOUOOOOOOOMAAAAAAAAAAPPPPPPPPPPPPPOOOOOOOOOSSOSSSSZZZ\r\nYYYYYKPYTYYYYYYYMMMMMMMNNNNNNNNNNRRRRRRRRRRHRTJJJIIZZZZZZZZZHHHHHHHHHHHHHPPPVVVVVGNUUUUOOOOOOOOOOMMMOAAAAAAPPPPPPPPPPPPPOOOOOOOOOSSSSSSSSSSZ\r\nYYYYKKKTTTYYYYYYMMMMMMMNNNNNNANAARRRRRRRRRRRRJJIIIIIZZZZZZZZHHHHHHHHHHHHZZZVVVVVGGNUUUUOOOOOOOOOMMOOOAPAHHHPPPPPPPPPPPPPPOOOOOOOOOSSSSSSSSSZ\r\nYYYYYKKKKTKKKKKMMMMMMMMNNNNNNAAAARLRRRRRRRRRRRIIIIIIZZZZZZZZHMHHHHHHWHZZZZZVVVVVGUUUUUUTOOOOOOOOOOOOLOAAHHHHPPPPPPPPPPPPPOOOOOOOOOSSSSSSSSSZ\r\nYYYYYYYKKKKKKKZZZMMMMNNNNNNNAAAAARLLRRRRRRRRRIIIIIIIZZZZIZZZZHHHHTHHZZZZVZZHHVVUUUUUUUZOOOOOOOOOOOOOOOCAAHHHHHPHPPPPPPPPPPPOSSOOOOOSBSSSSSJJ\r\nYYYYYYYKKKKKKKKKKMMMMMMNNNNAAAAAAAARRRRRRRRRRRPPIIIIIZIIIZZZZZHLHTHHZZZZZZZHHUUUUUUHUUUHOOOOOOKKKSSSSSCAAHHHHHHHHPPPPPPPPPSSSSSSOOOOBSSSSSJJ\r\nYYYYYYYKKKKKKKKMMMMMMMMNNNNAAAAAAAAAARRRRRRRRPPPPPIIIIIIZZZZZHHLZTZIZZZZZZZZZUUUUHHHUUUHHOOHOOKKKKKSSSSHHHHHHHHHPPPPPPPPPPPSNNNXNNNNNSSSSJJJ\r\nYYYYYYYKKKKKKKKKKMMMMMNNNNNAAAAAAAAAARRRRRRRRPPPPIIIIIIZZZZZZZZZZTZZZZZZZZZUUUUUUUHHHHHHHHOHHKKKKKKSSSSSSHHHHHHHHPPPPPPPCCCNNNNNNNNNNWSSJJJJ\r\nYRYYYYKKKKYYYKKKMMMMMMNNKKKKKKAAMMAAARRRRRRRPPPPPIIIIIIZZZZZZZZZZZZZZZZZZZTUUUUUUUUHHHHHHHHHHKKKKKDSSSSSSSHHHGGGHHHPPPPCCCCNNNNNNNNNNWWWJJJJ\r\nRRRYYYYYYYYYYYYYMMMMMNNNKKKKKKKAAMMAARRRRRRRPPPPPPPIIOIZZZZZZZZZZZVVZZZZZZTTTUUUTTUPPHHHHHHHHKKKKKKFSSHHHSHHGGGGGHNPPPCCRRCNNNNNNNNNNWWWJJJC\r\nRRRRYYYYYYYYYYYMMMMMHNNNVVKKKKKAHHMARRRRRRRRRPPPPFFOIOZZZZZZZZZVVVVVVZZZZZTTTUUUTTTPPPPHHHHHHKKKKKKKKKKHHHHHHGGGGGNNNPCCRRRRNNNNNNNNNWWWWJJC\r\nRRRRRRRYYYYYYYOOEOOMHHNNNNHHNNNHHIMMIRRRRRRRPPPPYOOOOOOZOOOOOVVVVVVVVZLZZZTTTTTTTTPPPPPPHHHHHKKKKKKKKKKHHHHHHGGGGGGNGRRRRRRRRNNNNMNNWWWWWVVC\r\nRRRRRRYYYYYYYOOOOOOMMHHNNTNNNNNHHIIIIRIIIPRRRRLOOFOOOOOOOOOOOVPVVVVVVVLZZTTTTTTTTTPPPPHHHKKKKKKKKKKKHHHHHHHHHGGGGGGGGGRRRRRRRNNNMMMMMWWWVVVV\r\nGRRRRYYYYYYYYOOOOOOOOOHOITNNNNNNHHIIRRIIIPPRRROOOOOOOOOOOOOOOOPVLLLLLLLZZTTTTTTTTTTPPPPHHKKKKKKKKKKHHHHHHMHHHGGGGGGGGGRRRRRRRNNNMMMMMWMWVVVV\r\nGRRRRRYYYYYVYOOOOOOOOOOOIINNNNNCCHIIIIIIIIPPPPOOOOOOOOOOOOOOOOPVVYLLLLLZTTTTTTTTTTTTPPGRHKKKKKKKKKKHHHHHMMMMMGGGGGGGGGRRRRRRRRNNMMMMMMMWWVVV\r\nGRRRRRYVYYYVYBOOOOOOOOIIIIOONNNCCIIIIIIIPPPPPPPPOOOOOOOOOOOOOOOVYYLLLLLTTTTTTTTTTNNNRRGRHHRKKFKKBKKBHHHMMMMMMGGGGGGGGGGRRRRRRNNMMMMMMMMWVVVV\r\nGGGGGGYVVVVVVVVOOOOOOOIIIIIINDNICCIIIIIIPPPPPPPPOOOOOOOOOOOOOOOOYLLLLLTTTTTTTTTTTNNRRRRRRRRRFFFBBBBBMMMMMMMMGGGGGGGGGGGRRRRRRRRRMMVVVMMMVVVV\r\nGGGGGGYVVVVVVVVVOOOOOOIIIIIIZIIIICIIIIPPPPPPPPPPOOOOOOOOOOOOMMMLLLLLLLLLTTTTTTNNNNNNRRRRRRRRBFFFBBBBMMMMMMMGGGGGGGGGGGGGSRRRRRRRRCVVVVVMVVVV\r\nGGGGGGGGVVVVVVVVOOOOOOIIIIIIIIIIIIIIIPPPPPPPPPPPOOOOOOOOOOOOOMMLLLLLLLLLLTTTENNNNNNNRRRRRRRRRFYFBBBBMMMMMMMMGGGGSSSAGGGKSSRCCCRRCCVVVVVVVVVV\r\nGGGGGGGGVVVVVVVVOOOOOOIIIIIIIIIIIPPIIPPPPPPPPPOPPOOOROOOOOOOOOMMLLLLLLLELLTTENENNNNRRRRRRRFFBFFFFFFFMMMMMMMMMGGMISSSSSGSSSSJCCCCCVVVVVFFFVVV\r\nGVGGGGGRRVVVVLVOOOOOOOIIIIIIIIIIIAPPPPOOOOOPOOOPPPOOOOOOOMMMMMMLLLLLLLLEEEEEEEENNNNNIIIRRRFFFFFFFFFMMMMMMMMMMGMMMSSSSSSSSSSSVCCCCVVVVVFFFFFF\r\nVVGGGGRRRVVVVLVOOOOOOOOIIIIIIIIIIAPAAAAOOOOOOPOOOOOOOOOOOSSMMMMMMLLLLLLEEEEEENNNNNNNIIIRRRFFFFFFFFFMMMMMPPMMMMMMSSSSSSSSSSSSCCCCVVVVVVFFFFFF\r\nVVRRRRRRRVVVLLKLOOOLLLOIIMMIIIAAIAPAAAAOOOOOOOOOOOOOOOHHOSSSSMSMLLLLLLLLEEEEENNNNNNNIIIRRRFFFFFFFFFMFMMMPMMMMMMMMMSSSSSSSSKKCCCCCCCVVVFFFFFF\r\nVVVVVRRRRVVVLLLLLLLLLLOOOIIIAAAAAAAAAAAAOOOOOOOOOOOOOOOSSSSSSSSMLLLLLLEEEEDNNNNNNNNNIIIRRGFFFFFFFFFMFMMHPMMPPPPMMMSSSSSSSSKCCCCVCCVVVVFFFFFF\r\nVVVVVRRRRVVLLLLLLLULLLOOOOOIAAAAAAAAAAABOOOOOOOOOOOOOOOSSSSSSSSMMLSSSLEEDEDLNDNNNNNNIIIGGGFFFFFFFFFMFMMPPPMMPPPPSSSSSSSSZKKKKVVVVVVVFFFFFFFF\r\nVVVVVVVRRVVLLLLLLLLLLLLOOOOOAAAAAAAAAAAAAAOOOOOOOOOOOOOSSSSSSSSSMLLSSEEYDDDDDDDNNNNNIIIGUFFFFFFFFFFFFMKPPPPPPPPSSSSZSZZZZKKKVVVVVVVFFFFFFFFF\r\nVVVVVVVVRVLLLLLLLLLLLLLOOOOOOAAAAAAAAAAAAAAOOOOOOOOOOOSSSSSSSSSLLLSSEEEEDDDDDDIIIIIIIIIUUFFFFFFFFFFFFMKPPPPPPPPPSSSZSZZZZZKVVVVVVVVVFFFFFFFF\r\nVVVVVVVVVVVLLLLLLLLLLLLLLOOOAAAAAAAAAAAAAOOOOOOOOOOOOOSSSSSSSSSSSSSSSESSSDDDDDIIIIIIIIIUUFFFFFFFFFFFFPPPPPPPPPPSSSSZZZZZZZZVVVVVVVVFFFFFFFFF\r\nIIVVVVVVVVVVLLLJLLLLLLLOLOOUAAAAAAAAAAAAAOOOOOOOOOOOSSSSSSSSSSSSSSSSSSSSSDDDDYIIIIIIIUUUFFFFFFLFFFSFFVVPPPPPPPPPPSSZZZZZZZZIVIVVIVVIFFFFFFFF\r\nIIIVHHHHHHVMMMLMSLLLLOOOOOUUAAAAAAAAAAAAAOOOOOOOEEEEEEESSSSSSSSSSMSSSSSSSDDDYYIIIIIIIGUUIFFPPFFFFFFFVVLLLLPPPPPPPPZZZZZZZZIIIIIIIIIIIIFFFFFF\r\nIVVVVHHHHHMMMMMMMMMLLOOUUOUAAAUAAAAAAAAAALNOOOOOEEEEEEEEEEEEESSSSSSSSSSSSYDYYYYYYYYGGHIIIIFYYYFPFFFVVVLLLLPQPPPPPZZZZZZZZZIIQIIIIIIIIIFFFFFF\r\nPVVVHHHHHHBMMMMMMMMMOOUUUUUUUUUAUAAAAAFANLNNNOOOEEEEEEEEEEEEESSSSSSSSSYYYYYYYYYYYYGGGHHIIIIYYYFVVSVVVVLLLLPPPPPPPPZZZZZZZZQQQQIIILIIIIIFFFFK\r\nPTVHHHHHHHBMMMMMMMMMOOOUUUUUUUUUUAUAAAANNNNNOOOOEEEEEEEEEEEEESSSSSSSSSSYYYYYYYYYYGGGGHHHHIIYYYYYVVVVVVLLLLVPEPPPZZZZZZZZZQQQQQQLLLLIXFFFFFFF\r\nTTHHHHHHHHMMMMMMMMMMMOUUUUUUUUUUUUUAAANNNNNNNOOAEEEEEEEEEEEEESSSSSSSSYYYYYYYYYYYYYGYYHHHHHIYYYYYYVVVVVLLLLLVVPPPZZZZZZZZZVVVVVVVVVVLXXFFFFFF\r\nDTTTHHHHHHMZMMMMMMMMMMUUUUUUUUUUUUAAAAANNNNNNNAAEEEEEEEEEEEEESSSSSSSSSYYYYYYYYYYYYYYYYHHHHISYYYYVVVVVVLLLLLVPPAAZZZZZZZZZVVVVVVVVVVLXXXFFFFF\r\nDTTTTNHHHZZZMMMMMMMMMMUUUUUUUUUUUUUQANANNNNNNNAAAGUUAEEEEEEEESSSSSSYYYYYYYYYYYYYYYYYYYHHHSSSSYYVVVVVVVLLLLLVVVAZZZZZZZZZZVVVVVVVVVVVVVXXXXFF\r\nDTTTTTHHHHZZMMMMMMMIIIUFUUUJWUUUDDXXNNNNNNNNNNNAGGUCAAAACCCCCSASSSSSSYYYYYYYYYYYYYYYYOOHKKSSSYVVVVVVVVLLLLVVVVVZZEEZZZZZZVVVVVVVVVVVVVXXXXFF\r\nDDTTTTHHHHHHWMMMMMIIIIIUUUUJWWWDDXXXXXNNNNNNNNNGGUUCACACCCCAAAAAASSSSYYYYYYYYYYYYYPYOOOHSSSSSSSWVVVVGVVVVVVVVVOOZEZZZZZZZVVVVVVVVVVVVVXXXXXX\r\nDTTTTTHHQHHHMMBMMMIIIIIIIIIWWWWWDXXXXXNNNNNNNNNUUUUCCCCCCCCAAAAAAASSOOYYYYYYYYYYYYYYOOOOOSSSSSSSBVBBVVVVVVOVVYOOOZZZVVVVVVVVVVVVVVVVVVXXXXXX\r\nDTTTDHHHQHHHBBBBMBIIIIIIIWWBWWWFXXXXXXXXNNNNNUKKUUUCCCCCCCCCCCAAAASOOVYGGGYYYYYYYYYYYOOOSSSSSSSSBBBBBBVVVVOOOOEOOFZZVVVVVVVVVVVVVVVVVVXXXXXK\r\nDDTDDDJHJJBBBBBBBBIIIIIIWYWWWWWWEXXXXXXXNQUUUUUUUUUUCCCCCCCAAAAAAOOOOOOGGGYYYYYYYOOOOOOOSSSSSSSSBBBBBVVVVVOOOOOOOOOZVVVVVVVVVVVVVVVVVVXXXXXK\r\nDDDDJDJJJBBBBBBBBBBBIIIWWYWWWWWWEXXXXXXDNNUUUUUUUUUUUUUCCCCAAAAAAAAOOBOGGGYYJYYYYYNOOOOOEESSSSSBBBOOOOOVOOOOOOOOOOORVVVVVVVVVVVVVVVVVVXXXXXX\r\nDDDDJDJJJBBZZBBBBBBBBBIWWWWWWWWWXXXXXXXXNNUUUUUUUUUUUUCCCCCAAAAAAAOOOOOGGGGJJYYYYYNONNOOOESEBBBBBBOOOOOOOOOOOOOOOOORVVVVVVVVVVVVVVVVVVXXXXVV\r\nDDDDJJJJJBBBBBBBBBBBBYWWWWWWWWWWKXXXXXXXNNXXUUUUUUUUUUCCCCCAAAAAAAOOOOGGGGGCJJYYYNNOONOOEEEEBBBBBBBBOOOOOOOOOOOOORRRVVVVVVVVVVVVVVVVVVTXXXVV\r\nDDDJJJJJJHBBBBBBBBBBYYQQQWWWWWWKKKXXXXXXXXXXUUUUUUUUUUUCECCAAAAAAAAGOOGGGGCCCJJNNNNNNNNNNNNNNBBBBBBBXXXOOOOOOOOOORRRVVVVVVVVVVVVVXXXXXTLXXVV\r\nDDDDDJJJJHBBBBBBBBBBBQQHHWWWWWWWKXXXKKXXXUUUUUUUUUUUUUEEECAAAAAAAAGGGGGGGGCCCCNNNNNNNNNNNNNNBBBBBBBBXXXXXXOOOOJOORRRVVVVVVVVVVVVVXTXXXTLXXVV\r\nDDDDDJJJJBBBBBBBBBBBQQQNWWWNWWWKKKXKKKKKXUUUUUUUUUUUUUUEEAAAAAAAAAGGGGGGGGCCCCCNNNNNNNNNNNNNBBBBBBBBBXXXXXXOXCXRRRRRVVVVVVVVVVVVVTTTTTTTVVVV\r\nDDDDVVJJXXBBBBBBMBBBQQQNNWWNWWWWKKKKKKKKXLUUUUUUUUUUUUUEEAAAAAAAAAAGTGNCCGCCCCCCCNNNCCVXNXBBBBBXBBBXXXXXXXXXXXXXRRRRVVVVVVVVVVTTTTTTTTTMEEVV\r\nVDVDVVVXXXBBBBBBBBBQQQQNNNNNNWWWWKKKKKKKXXVVVVUUUUUUUUUEEEEEEEEAAAATTGNNCCCCCCCCCCCCCCCXXXXBXXXXXXXXXXXXXXXXXXXXRRRRRRBBBBTTTTTTTTTTTTTMEEVV\r\nVVVVVVVXXBBBNBBBQQBBQQQNNNNNNNNNVKVKKKKVXXVVVVUUOUUUEUEEEEEEDEEEWCCCTGNNNCCCCCCCCCCCCCCXXXXXXXXXXXXXXXXXXXXXXXRXRRRBBBBBBBBTTTTTTTTTTTTEEEEE\r\nVVVVVVVVXXQBNBQQQQQQQQQQNNNNNNNNVVVKKKKVVVVJIIIIIIIIIIIIEEEEEEEECCCCCNNNCCCCCCCCCCCCCXXXXXXXXXXXXXXXXXXXXXXXRRRRRRBBBBBBBBBTTTTTTTTTTTTEEEEE\r\nVVVVVVVXXXQQQQQQQQQQQQQQNNNNNNNNVVVVKVVVVJJJIIIIIIIIIIIIEEEEFFCCCCCCCCOOCCCCCCCCCCCCXXXXXXXXXXXXXXXXXXXXXXXXRRRRRBBBBBBBBBBTHHHHHHHTETTEEEEE\r\nVVVVVVVXXQQQQQQQQQQQQQQQQNNNLNNNNVVVVVVVJJJJIIIIIIIIIIIIEEEFFFCCCCCCCOOOOOCCCCCCCCCCXXXXXXXXXXXFXXXXXXXXXXXXXRRRRRBBBBBBBBBTHHHHHHHTETIEEEEE\r\nVVVVVVVVXQQQQQQQQQQQQQQQTTTTOOOOVVVVVVVVJJJJJJEIIIIIIIIIEEFFFFFFFCCCCOOOOOFCCCCCCCCCCCXXXXXXXXXXUXXXXXXXXXXXTTRRBBBBBBBBBVVTHHHHHHHEEEEEEEEE\r\nVVVVVVHHQQQQQQQQQQQQQQQQQTTTOOOOOOVVVVVVPJJJJJJIIIIIIIIIEEFEEEEFZCCCOOOOOFFCCCCCCCCCCXXXXXXXXXXUUXXXXXXXXXXXTTTRRBBBBBBBVVVTHHHHHHHEEEEEEEEE\r\nVVVVVVHEQQQQQQQQQQQQQQQQTTTOOOOOOOVVVVVPPJJJJIIIIIIIIIIIEEEEEEZZZZCOOOOOOOFCCCCCCCCCCCXXXXXXXXXUQXTTXXXXXXXXTTTTRRBBBVVVVVVTHHHHHHHEEEEEEEEE\r\nVVVVVREETEEEEQQQQQQQTTTTTTTTOOOOOOVOVVVPPJJJJIIIIIIIIIIIEEEEEEEZZZZZOOAAOAFCCCCCCCCCCCXXXXXXXXQQQQQTTTXXXXXTTTTTRRRBBBBVVVVVHHHHHHHEEEEEEEEE\r\nVVVVDEEEEEEYQQQQQQKQKKKKTTOOOOOOOOOOOOOPPPPJJIIIIIIIIIIIEEEEEEZZZZZZAAAAOAFPCCCCCCCDFXXXXXXXXQQQQQQTTTTTTTTTTTTTTTRBCCVVVVVVVHHHHHHTTEEEEEEE\r\nVVVVDDEEEEEEHQQQQQKKKKKKKOOOOOOOOOOOPPPPPPPJJJJIIIIIIIIIEEEEEEEEIZZZZZAAAAADCCCCDCCDXXXGXXQQXQQQQQTTTTTTTTTTTTTTTTTTCCCVVVVVVHHHHHHTEEEEEEEE\r\nVVVDDDEEEEEYHQQQQQQKKKKKKKKOHOOOOOOPPPQPPQQJQQQIIIIIIIIIEEEEEEEEZZZZAAAAAADDDDDDDCCDDXXXXXQQQQQQQQTTTTTTTTTTTTTTTTCCCCCVVVVVVVVVVTTTEEEEEEEE\r\nVVVDDEEEEEYYYYYYQYGKKKKKKKKKOOOOOOOPPQQQQQQQQQQQQQPPEEEEAEEEEEEEZFZZKAAAADDDDDDDDDDDDDDHHHQQQQQQQZATTTTTTTTTTTTTTTCCCCCVVVVVVVVVVVEEEEEEEEEE\r\nVVVDEEEEEEEYYYYYQYGKKKKKKKKKKOOOOMPPPQQQQQQQQQQQQPPPPLELAEEEEEEEEFKKKAADDDDDDDDDDDDDDDDAHHQQQQQQQZANTTTTTTTTTTTTTTCCCVVVVVVVVVVVVVEEEEEEEEEE\r\nLVVDEEEEEEYYYYYYYYYKKKKKKKKKKOOOMMMMPPQQQQQQQQQQQPPPPPELAAAEEEEPEFKKKDDDDDDDDDDDDDDDDDDAHHQQQQQQQZATTTTTTTTTTTTTTTCCCVVVVVVVVVVVIEEEEEEEEEEE\r\nVVVEEEEEEEYYYYYYYYYYYKKKKKKKKKMOMMMMPPPQQQQQQQQQQQPPAPAAAAAMEEEPPKKKKDDDDDNDDDDDDDDDDDAAQQQQQQQQQAATTTTTTTTTTTTTTCCCCVAVAVVVVVVVVUUUUCCPPEEE\r\nRRRRRRREEYYYYYYYYYWYYYYKKKKKKPMMMMPPPQPQQQQQQQQQQQQPAAAAAAAEEEPPPKKKDDDDDTNDPCDDDDDDDDAAAQQQQQQYQQAAATAATTTTCTTTCCCCAAAAAAAVVVVVVVUCCCPPCCCC\r\nRRRRRRRRRRYYYYYYYYYYYYYKKKKKKKBMMMPPQQQQQQQQQQQQQQAAAAAAAATTEEPPKKKKKKKTTTTCCCCDDDDAAAAAAQQQQQQYQYAAAAAATTTTCCCCCCCAAAAAAAAVAAVVPCCCCCCCCCCJ\r\nRRRRRRRRRYYYYYYYYYYYYYYKKKKKKKKMMMCCWWQQQQQQQQQQQAAAAAAAAAEEEEKKKKKKKKKTTTTCCCSDDDDDAAAYYGQQQQYYYYAAAAAAAAATCCCCCCCCCAAAAAAAAAAACCCCCCCCCCCC\r\nRRRRRRRRRYYYYYYYYYYYYYYKMMKKMKMMMMCCCCCQQQQQQQQAAAAAAAAAAAAAAADDKKKKKKTTTTCCVCCCCCDDDAAYGGQQYYYYYYAAAAAAAAATAACCCCCCCAAAAAAAAAAAACCCCCCCCCCC\r\nRRRRRRRRRYYYYYYYYYYYYYYKKMMMMMMMCCCCCCCQQQJQQQAAAAAAAAAAAAAADDDDDKTVKTTTTCCCVCCCCCCDDCAAGGGGGYYYYAAAAAAAAAAAAACDDDDCCAAVAAAAAAFACCCCCCCCCCCC\r\nRRRRRRRRRYYYYYYYYYYYYYYYMMMMMMMCCCCCCCCQAIISQQQAAAAAAAAAAAAAADDDDKTTTTTTTCCCCCCCCCDDDCAAGGGGGYYYYAYAAAAAAAAACCCCDDDCCDDVAABAAAACCCCCCCCCCCCC\r\nTRRRRRRORYYYYYYYYYYKYTTMMMMMMCCCCCCIIICCIXISQQAADAAAAAAAAAAAADDDDTTTTTTTTCTTCCCCCCCCCCAGGGGGGYGYYYYYAAAAAAAAACCCDDDDDDDDDAAAAAAACCCCCCCCCCCC\r\nTTRRRROOOYYYYYYYWYYTYTTTTMMMMMCCCCCCCIIIIIIQQQADDDDAAMAAAAAADDODOOTTTTTTTTTCCECCCCCCCCGGGGGGGGGGGYYYYYAAAAACCCCDDDDDDDDDDAAAAAACCCCCCCCCCCCC\r\nTTTRTROOOOYYYYYYTTTTTTTTTTMMMMCCCCCIIIIIIIIQZZDDDDAAMMAAAAADDOOOOTTTTTTTTTTCCCCCCCCCCCGGGGGGGGGGGGGAAAAAAAAACCDDDDDDDDDDDCAAAAAACCCCCCCCCCCC\r\nTTTTTOOOOYYLLYLYLTTTTTTTTTMMTTCZCICIIIIIIIIIDDDDDMMMMMMAAAOOOOOOOOJTTTTTTTTTTCCCCCCCCGGGGGGGGGGGGGAAAAAAAAACCCDDDDDDDDDCCCCAACCCCCCCCCCCCCCC\r\nTTTTTOOOOOOOLLLLLTTTTTTTTTTTTTCIIIIIIIIIIIIIDDDDDDDMMMMMAAOOOOOOOOOTTTTTTTTCCCCCCCCCGGGGGGGGGGGGGNNNAAALACACCDDDDDDDDDDCCCCAACCCCCCCCFFCCCCQ\r\nTTTTTTOOOOOOOLLLLLLATTTTTTTTTTIIIIIIIIIIIIINNNNNNDMMKKMNOOOOOOOOOOOOOOTTTTTTCTCSCCCSGGGGGGGGGGGOOONNNAACACCCDDDDDDDDDDDDCCCCCCCFFFFFFFFFFCCQ\r\nTTTTTTOOOOOOOLLOLLLAATTTTTTTKTIIIIIIIIIIIIINNNNNNDUUKKKOOOOOOOOOOOOOOOTTTTTTTTCSSCCSDGGGGGGGGGGGOOONNACCACCCDDDDDDDDDDDDCCCCCCCCFFFFFFFFFFFF\r\nTTTTTOOOOOOOOOOOLAAAATTTTTKKKTIIIIIIIIIIIIINNNNNNUUUUUUOOOOOOOOOOOOOOOOTTTTTTTSSSSSSDDSSGGGGFGGGOOOCCCCCCCDDDDDDDDDDDDDDCCCCCCCFFFFFFFFFFFFF\r\nTTTTTOOOOOOOOOOOOAHAATATKKKKTTTKIIIIIISIIEEEEUUUUUUUUUUJOOOOOOOOOOOOOOTTTTTTTSSSSSSSSSSFFFFFFFFGGOOOOACCCCCDDDDDDDDDDDDCCCCCCFFFFFFFFFFFFFFF\r\nTTTTTOOOOOOOOOOOOOAAATAKKKKKTKKKEEIIIEEIIEEEEEUUUUUUUUUJJOOOOOOOOOOOOOTTTTTTTTSSSSSSSSFFFFFFFFGGOOOOOCCCCCCIIDDDDDDDDDDCCCCCCFFFFFFFFFFFFFFF\r\nTTTTTTOOOOOOOOOXOOAAAAAAAKKKKKKKKKEEEEEIIIIEEEEUUUUUUUUPOOOOOOOOOOOOTTTTTTTXTSSSSSSSSSSSFFFOOOOOOOOOOOCCCICIIDDDDIDDDDDDDDCCCCCFFFFFFFFFFFFF\r\nTTTTTTOOOOOOOOOOAAAAXXXAKKKKKKKKKKEEEEEEEEEEEEEUUUUUUUUPOPPOOOOOOOOTTTTTTTFSSSSSSSSSSSSSFFOOOOOOOOOOOOCCCIIIIIDDDIIIDTDDDCCCCCCFFFFFFFFFFFFF\r\nTTTTTTOOOOOOOOOOXAAAAAXXKKKKKKKPPEEEEEEEEEEEEEEEEUUUUUPPPPPPUUUUOUUTTTTTTTFFFBBSSSSSSSKXFFFOOOOOOOOOOOCCIIIIIIIIIIIIITTDDFHHCHCHHFFFFFFFFFFF\r\nTTTTTTTOOOOOOOXXXXXXXXXXXKKKKKPPEEEEEEEEEEEEEEEEEPUUUPPPPPPGPUUUUUUTTTTTTTTFFFFSSSSSKKKXFFFXOOOOOOOOOOOOOIIIIIIIIIIIITTTTHHHHHHHHFFFFFFFFFOF\r\nTTRRTTTOOOOQOOXDDXXXXXXXXXKKPPPPEEEEEEEEEEEEEEEEEPPPPPPPPPPPPPUUUUURRTTTTTBFFFFFSSSSSKKXXXXXOOOOOOOOOOOOOIIIIIIIIIITTTGGTHHHHHHHHHHFFFFFFFFF\r\nRRRRRRTTOOOQQDXXDDXXXXXXXXKKPPAAEEEEEEEEEEEEEEEEEEPPPPPPPPPPPPUUUURRRRRTTBBFFFFVFSSSSSKXXXXXXOOOOOOOOOOOIIIIIIIIIIITTTGGEEHHHHHHHHHFFFFFFFFF\r\nWWRRRRTTTTOOQDDDDDXXXXXXXXKKPPAAAAENNEEAEEEEEEEEEEPPPPPPPXPPHPUUUURRRRRTTBBBFFFFFSSSSSXXXXXXXXOOOOOOOOOIIIIIIIIIIIIIIGGGEHHHHHHHHHFFFFFFFFCC\r\nWWRRRRRTRRROQQQDDDDDDXXXXXXXXPAAACNNNEEAAAEEEEEEEQQQQPPPXXPXXXXXXRRRRREETTFFFFFFFFFFSKXXXXXXYXOOOOAAOOOOOIIIIIIIIIIITTGGHHHHHHHHHHFFFFWWFCCC\r\nWURRRRRRRRRDDQDDDDDDDXXXXXXXPPAAANNNNNAAAAAEEELLPQQQQPPMXXXXXXXXXRRREREEEEFFFFFFFFUSSSXXXXXXXXXXXOAAOFFFFIIIIIIIIIITTTGGGHHHHHHHHHFFZFNNCCCC\r\nUUUUURRRRRRDDDDDDDDDDDDXXXXXPXAAAANNAAAAAAAALELLLQQQQPMMMMMXXXXXXRRREEEEEEEEFFFFFFUSSUUXXXXXXXXXOOAAOFFAFIIIIIIPPPPPPPPGGGHHHHHHHHHHHNNNNNCC\r\nTTUUUURRRRDDDDDDDDDDDDDDXXXXPXAAAANNAAAAAAOOLLLLLQQQQMMMMMMPPXXRRRRRREEEEEEEEEFFFUUUUUUUXXXXXOXOOOAAAAAAAIIIIIIPPPPPPPPPPPGHHHHHHHHHINNNNNCC\r\nTTUUURRRNRRRNDDDDDDDDDXXXXXXXXXXAAAAAAAAAAOLLLQQQQQQQMMMMMPPPXRRRRRRREERRRREEEEKUUUUUUUCXXOOOOOOOAAAAAAAACCIXHHPPPPPPPPPPPGHHHHHHHHHINNNNNNC\r\nTTUNNRRRNRNRNNDDDDDDDDDDXHXXXXXXAAAAAAAAAQQQQQQQQQQQQMMPPPPPPXRRRRRRRRRRRRREEEKKUUUUUUUCOOOOCOOOOAAAAAAAACXXXXSPPPPPPPPPPPGHHHHHHHHHHNNNNNNN\r\nTTTTNNNNNNNNNNDDDDDDDDDDXHXXXAAAAAAAAAAAAQQQQQQQQQQQQOMPPPPPPXRRRRRRRRRRRRKKKEKKKUUCCCUCCCCCCOOOOAAAAAALACXWXXSISZZPPPPPPPGGHHTHHTHNNNNNNNNN\r\nTTTTNNNNNNNNNNNNDDDDDDDDDDAAAAAAAAAAAAAAOQQQQQQQQQQQPPPPPPPPPVRRRRRRRRRRRKKKKKKKUUUCCCCCCCCCOOOOOOHAAAAAACXWWXSSSZZPPPPPPPKKKTTTTTHHNNNNNNNN\r\nTTTTNNNNNNNNNNNNDDDDYYYYDDDAAAAAAAAAAAAAHHOORRROOQQQOPPPPPPPPPRRRRRRRRRRRRKKKKKKUUUCCCCCCCCCCCOOOOHHAAAAAHHWWWHHSSZPPPPPPPGTTTTTTTTNNNNNNQQQ\r\nTTTTNNNNNNNNNNNDDYDYYYYYYAAAAAAAAAAAAAAHHHORRRRROOOOPPPPPPPPPPPPRRRRRRRKKKKKKKKKUUCCCCCCCCCCCCOOOHHHHHAHHHHWWHHSSSSPPPPPPPTTTTTTTTNNNNNNQQQQ\r\nTTTNHNNNNHHHHNNDYYYYYYYYYAAYYAAAAAAAAAHHHRMMRRRROOOPAPPPPPPPPPPPPKRRRRRRKKKKKKCCUUCCCCCCCCCCCCCHHHHHHHHHHHHHHHHHHSGPPPPPPPTTTTTTTTTNNNNNNNNQ\r\nTTTNNNNNNHHHHHHDYYYYYYYYYKKYYYBYAAAAAAHHMRMMMRRRRRPPPPPPPPPPPPPKPKRRRRRIKKKKKKCCCCCCCCCCCCCCCCCHHHHHHHHHHHHHHHHHHHGPPPPPPPTTTTTTTTTTNNNNNNNN\r\nTTNNTNNNNHHHHHHYYYYYYYYYYKKYYYYYAAAAAAHMMMMMMRRRRRRRRRPPPPPPLPPKKKKRRRRIIKKKKKKCCCCCCCCCCCCCCCLLLCCHHHHHHHHHHHHHHHGPPPPPPPTTTTTTTTTTTNNNNNNN\r\nTTTTTTNHNHHHHHYYYYYYYYYYYKJYYYYYAAAAAHHMMMMXRRRRRRRRRRRPPPPPRKKKSSSSRRRRSSSKKKKKCCCCCCCCCCCCCCCCCCCHHHHHHHHHHHXXXXXXXXUUUTTTTTTTTTTNNNNNNNNN\r\nNNNTNNNHHHHHHHHYYYYYYYYYYYYYYYYYYAHAHHHHHMMXXRXRRRRRRRRRPPRRRRRKSSSSSSSSSSSKKKKKKCCCCCCCCCCCCCCCCHHHHHHHHHHHHHHHXXXXXUUUUTTTTTTTTTTNNNNNNNNN\r\nNNNNNHHHHHHHHHHYYYYYYYYYYYYYYYYYYHHHHHHHHXXXXXXRRRRRRRRRRPRRRRRKSSSSSSSSSSSSKKKKQCCCCCCCCCCCCMCCHHHHHHHHHHHHHHHHXXXXXXUUUTTMTTNNNTTNNNNNNNNN\r\nNNNNNNNNHHHHHHHYHYYYYYYYYYYYYYYYYHHHHHHHXXXXXXXRRRRRRRRRRRRRRRRKSSSSSSSSSSSSKKKKQQQQCCQCQQQQQHHHHHHHHHHHHHHHHHHXXXXXXXXXXTTNNNNNNNNNNNNNNNNN\r\nNNNNNNNNHHHHHHHHHYYYYYYYYYYYYYYYYYYHHHHHXXXXXXXRRRRRRRRRRRRRRRSSSSSSSSSSSSSSKKKKQQQQQQQQQQQQQQHHHHHHHHHHHHHHHXXXXXXXXXXXXXTNNNNNNNNNNNNNNNNN")
    {
        private List<Region> regions;
        protected override void Solve()
        {
            ConstructMatrix();
            regions = new List<Region>();
            matrix.MatrixForEach((i, j, c) =>
            {
                if (!regions.Any(x => x.Contains((i, j))))
                {
                    Region region = new Region(c, this);
                    regions.Add(region);
                    region.Search((i, j));
                }
            });
            result = regions.Sum(x => (part1 ? x.CalculatePerimeter() : x.CalculateSides()) * x.CalculateArea());
            if (testing)
            {
                foreach (Region region in regions)
                {
                    Console.WriteLine($"{region.character}: area: {region.CalculateArea()}   perimeter: {region.CalculatePerimeter()}   sides: {region.CalculateSides()}");
                }
            }
        }
    }

    internal class Region(char c, Day12 problem)
    {
        public char character = c;
        private Queue<(int x, int y)> check = [];
        private List<(int x, int y)> positions = [];
        private Day12 problem = problem;
        private List<(int, int)> checkd = [];


        public bool Contains((int x, int y) position) => positions.Contains(position);

        public void Search((int x, int y) position)
        {
            positions.Add(position);
            foreach (var item in problem.AdjacentPositions(position))
            {
                if (!positions.Contains(item)) 
                    check.Enqueue(item);
            }
            while (check.TryDequeue(out var pos))
            {
                if (checkd.Contains(pos)) { continue; }
                checkd.Add(pos);
                if (positions.Contains(pos) || problem.MatrixAt(pos) != character) { continue; }
                if (problem.MatrixAt(pos) == character)
                {
                    positions.Add(pos);
                }
                foreach (var item in problem.AdjacentPositions(pos))
                {
                    if (!positions.Contains(item))
                        check.Enqueue(item);
                }
            }
        }

        public long CalculateArea() => positions.Count;

        public long CalculatePerimeter()
        {
            long result = 0;
            foreach (var position in positions)
            {
                result += problem.OutOfBoundsAdjacentCount(position);
                foreach (var item in problem.AdjacentPositions(position).Where(x => problem.MatrixAt(x) != character))
                {
                    result++;
                }
            }
            return result;
        }

        private bool IsEdge((int x, int y) position)
        {
            if (problem.OutOfBoundsAdjacentCount(position) > 0) { return true; };
            foreach (var item in problem.AdjacentPositions(position).Where(x => problem.MatrixAt(x) != character))
            {
                return true;
            }
            return false;
        }

        public long CalculateSides()
        {
            long result = 0;
            List<(int x, int y)> edge = positions.Where(IsEdge).ToList();
            List<List<int>> faces = [];
            //North faces
            var northFaces = edge.Where(x => !problem.InBounds((x.x, x.y - 1)) || problem.MatrixAt((x.x, x.y - 1)) != character).Select(x => x.x);
            foreach (var x in northFaces)
            {
                if (faces.Count == 0)
                {
                    faces.Add([x]);
                    continue;
                }
                bool found = false;
                for (int i = 0; i < faces.Count; i++)
                {
                    var face = faces[i];
                    for (int j = 0; j < face.Count; j++)
                    {
                        int x2 = face[j];
                        if (Math.Abs(x - x2) == 1)
                        {
                            face.Add(x2);
                            found = true; break;
                        }
                    }
                    if (found) { break; }
                    else
                    {
                        faces.Add([x]);
                    }
                }
            }
            result += faces.Count;
            faces.Clear();
            //South faces                                                                                                                 
            var southFaces = edge.Where(x => !problem.InBounds((x.x, x.y + 1)) || problem.MatrixAt((x.x, x.y + 1)) != character).Select(x => x.y);
            foreach (var x in southFaces)
            {
                if (faces.Count == 0)
                {
                    faces.Add([x]);
                    continue;
                }
                bool found = false;
                for (int i = 0; i < faces.Count; i++)
                {
                    var face = faces[i];
                    for (int j = 0; j < face.Count; j++)
                    {
                        int x2 = face[j];
                        if (Math.Abs(x - x2) == 1)
                        {
                            face.Add(x2);
                            found = true; break;
                        }
                    }
                    if (found) { break; }
                    else
                    {
                        faces.Add([x]);
                    }
                }
            }
            result += faces.Count;
            faces.Clear();
            //East faces                                                                                                                  
            var eastFaces = edge.Where(x => !problem.InBounds((x.x + 1, x.y)) || problem.MatrixAt((x.x + 1, x.y)) != character).Select(x => x.x);
            foreach (var x in eastFaces)
            {
                if (faces.Count == 0)
                {
                    faces.Add([x]);
                    continue;
                }
                bool found = false;
                for (int i = 0; i < faces.Count; i++)
                {
                    var face = faces[i];
                    for (int j = 0; j < face.Count; j++)
                    {
                        int x2 = face[j];
                        if (Math.Abs(x - x2) == 1)
                        {
                            face.Add(x2);
                            found = true; break;
                        }
                    }
                    if (found) { break; }
                    else
                    {
                        faces.Add([x]);
                    }
                }
            }
            result += faces.Count;
            faces.Clear();
            //West faces                                                                                                                  
            var westFaces = edge.Where(x => !problem.InBounds((x.x - 1, x.y)) || problem.MatrixAt((x.x - 1, x.y)) != character).Select(x => x.x);
            foreach (var x in westFaces)
            {
                if (faces.Count == 0)
                {
                    faces.Add([x]);
                    continue;
                }
                bool found = false;
                for (int i = 0; i < faces.Count; i++)
                {
                    var face = faces[i];
                    for (int j = 0; j < face.Count; j++)
                    {
                        int x2 = face[j];
                        if (Math.Abs(x - x2) == 1)
                        {
                            face.Add(x2);
                            found = true; break;
                        }
                    }
                    if (found) { break; }
                    else
                    {
                        faces.Add([x]);
                    }
                }
            }
            result += faces.Count;
            faces.Clear();
            return result;
        }
    }
}

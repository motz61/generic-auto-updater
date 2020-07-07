﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Windows.Forms;
using M2BobPatcher.TextResources;

namespace M2BobPatcher.ExceptionHandler {
    static class Handler {

        public static void Handle(Exception ex) {
            switch (ex) {
                case AggregateException e1:
                    Handle(e1.InnerExceptions.First());
                    break;
                case FileNotFoundException e2:
                case DirectoryNotFoundException e3:
                    Repatch(ErrorHandlerResources.AV_FALSE_POSITIVE, ErrorHandlerResources.ERROR_TITLE_AV);
                    break;
                case WebException e4:
                case HttpRequestException e5:
                case InvalidDataException e6:
                case DecoderFallbackException e7:
                    Repatch(ErrorHandlerResources.TIMEOUT_DOWNLOADING_RESOURCE, ErrorHandlerResources.ERROR_TITLE_NETWORKING);
                    break;
                case SecurityException e8:
                case UnauthorizedAccessException e9:
                case PathTooLongException e10:
                case IOException e11:
                    Repatch(ErrorHandlerResources.ERROR_IO_EXPLORER, ErrorHandlerResources.ERROR_TITLE_EXPLORER);
                    break;
                default:
                    Repatch(ErrorHandlerResources.UNKNOWN_ERROR, ErrorHandlerResources.ERROR_TITLE_UNKNOWN);
                    break;
            }
        }

        private static void Repatch(string text, string caption) {
            switch (MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error)) {
                case DialogResult.OK:
                    Application.Exit();
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }
    }
}

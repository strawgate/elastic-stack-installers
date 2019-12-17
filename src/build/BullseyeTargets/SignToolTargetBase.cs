﻿using ElastiBuild.Extensions;
using Elastic.Installer;

namespace ElastiBuild.BullseyeTargets
{
    public abstract class SignToolTargetBase<T> : BullseyeTargetBase<T>
    {
        protected static (string certPass, string SignToolArgs) MakeSignToolArgs(BuildContext ctx)
        {
            var ap = ctx.GetArtifactPackage();

            var pc = ctx.Config.GetProductConfig(ap.TargetName);
            var (certFile, certPass) = ctx.GetCertificate();

            return (
                certPass,
                string.Join(' ',
                    "sign",
                    "/v",
                    "/tr", ctx.Config.TimestampUrl.Quote(),
                    "/d", pc.PublishedName.Quote(),
                    "/du", pc.PublishedUrl,
                    "/f", certFile.Quote(),
                    "/p", certPass.Quote(),

                    // extra space before binary name
                    string.Empty)
                );
        }
    }
}

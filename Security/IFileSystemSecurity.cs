using System;
using System.Security.AccessControl;
using System.Security.Principal;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Security {
    [PublicAPI]
    public interface IFileSystemSecurity {
        [CanBeNull] IdentityReference GetOwner([NotNull] Type targetType);
        void SetOwner([NotNull] IdentityReference identity);
        [CanBeNull] IdentityReference GetGroup([NotNull] Type targetType);
        void SetGroup([NotNull] IdentityReference identity);
        void PurgeAccessRules([NotNull] IdentityReference identity);
        void PurgeAuditRules([NotNull] IdentityReference identity);
        void SetAccessRuleProtection(bool isProtected, bool preserveInheritance);
        void SetAuditRuleProtection(bool isProtected, bool preserveInheritance);

        [CanBeNull] string GetSecurityDescriptorSddlForm(AccessControlSections includeSections);
        void SetSecurityDescriptorSddlForm([NotNull] string sddlForm);
        void SetSecurityDescriptorSddlForm([NotNull] string sddlForm, AccessControlSections includeSections);

        [NotNull] byte[] GetSecurityDescriptorBinaryForm();
        void SetSecurityDescriptorBinaryForm([NotNull] byte[] binaryForm);
        void SetSecurityDescriptorBinaryForm([NotNull] byte[] binaryForm, AccessControlSections includeSections);
        bool ModifyAccessRule(AccessControlModification modification, [NotNull] AccessRule rule, out bool modified);
        bool ModifyAuditRule(AccessControlModification modification, [NotNull] AuditRule rule, out bool modified);
        bool AreAccessRulesProtected { get; }
        bool AreAuditRulesProtected { get; }
        bool AreAccessRulesCanonical { get; }
        bool AreAuditRulesCanonical { get; }

        [NotNull] Type AccessRightType { get; }
        [NotNull] Type AccessRuleType { get; }
        [NotNull] Type AuditRuleType { get; }

        [NotNull] AuthorizationRuleCollection GetAccessRules(bool includeExplicit, bool includeInherited, [NotNull] Type targetType);
        [NotNull] AuthorizationRuleCollection GetAuditRules(bool includeExplicit, bool includeInherited, [NotNull] Type targetType);
        [NotNull] AccessRule AccessRuleFactory([NotNull] IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type);
        [NotNull] AuditRule AuditRuleFactory([NotNull] IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags);
        void AddAccessRule([NotNull] FileSystemAccessRule rule);
        void SetAccessRule([NotNull] FileSystemAccessRule rule);
        void ResetAccessRule([NotNull] FileSystemAccessRule rule);
        bool RemoveAccessRule([NotNull] FileSystemAccessRule rule);
        void RemoveAccessRuleAll([NotNull] FileSystemAccessRule rule);
        void RemoveAccessRuleSpecific([NotNull] FileSystemAccessRule rule);
        void AddAuditRule([NotNull] FileSystemAuditRule rule);
        void SetAuditRule([NotNull] FileSystemAuditRule rule);
        bool RemoveAuditRule([NotNull] FileSystemAuditRule rule);
        void RemoveAuditRuleAll([NotNull] FileSystemAuditRule rule);
        void RemoveAuditRuleSpecific([NotNull] FileSystemAuditRule rule);
    }
}
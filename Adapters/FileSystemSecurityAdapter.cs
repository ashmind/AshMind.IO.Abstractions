using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using AshMind.IO.Abstractions.Security;
using JetBrains.Annotations;

namespace AshMind.IO.Abstractions.Adapters {
    public class FileSystemSecurityAdapter : IFileSystemSecurity {
        [NotNull] private readonly FileSystemSecurity _fileSystemSecurity;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemSecurityAdapter"/> class.
        /// </summary>
        public FileSystemSecurityAdapter([NotNull] FileSystemSecurity fileSystemSecurity) {
            if (fileSystemSecurity == null)
                throw new ArgumentNullException("fileSystemSecurity");

            _fileSystemSecurity = fileSystemSecurity;
        }

        public virtual IdentityReference GetOwner(Type targetType) {
            return _fileSystemSecurity.GetOwner(targetType);
        }

        public virtual void SetOwner(IdentityReference identity) {
            _fileSystemSecurity.SetOwner(identity);
        }

        public virtual IdentityReference GetGroup(Type targetType) {
            return _fileSystemSecurity.GetGroup(targetType);
        }

        public virtual void SetGroup(IdentityReference identity) {
            _fileSystemSecurity.SetGroup(identity);
        }

        public virtual void PurgeAccessRules(IdentityReference identity) {
            _fileSystemSecurity.PurgeAccessRules(identity);
        }

        public virtual void PurgeAuditRules(IdentityReference identity) {
            _fileSystemSecurity.PurgeAuditRules(identity);
        }

        public virtual void SetAccessRuleProtection(bool isProtected, bool preserveInheritance) {
            _fileSystemSecurity.SetAccessRuleProtection(isProtected, preserveInheritance);
        }

        public virtual void SetAuditRuleProtection(bool isProtected, bool preserveInheritance) {
            _fileSystemSecurity.SetAuditRuleProtection(isProtected, preserveInheritance);
        }

        public virtual string GetSecurityDescriptorSddlForm(AccessControlSections includeSections) {
            return _fileSystemSecurity.GetSecurityDescriptorSddlForm(includeSections);
        }

        public virtual void SetSecurityDescriptorSddlForm(string sddlForm) {
            _fileSystemSecurity.SetSecurityDescriptorSddlForm(sddlForm);
        }

        public virtual void SetSecurityDescriptorSddlForm(string sddlForm, AccessControlSections includeSections) {
            _fileSystemSecurity.SetSecurityDescriptorSddlForm(sddlForm, includeSections);
        }

        public virtual byte[] GetSecurityDescriptorBinaryForm() {
            return _fileSystemSecurity.GetSecurityDescriptorBinaryForm();
        }

        public virtual void SetSecurityDescriptorBinaryForm(byte[] binaryForm) {
            _fileSystemSecurity.SetSecurityDescriptorBinaryForm(binaryForm);
        }

        public virtual void SetSecurityDescriptorBinaryForm(byte[] binaryForm, AccessControlSections includeSections) {
            _fileSystemSecurity.SetSecurityDescriptorBinaryForm(binaryForm, includeSections);
        }

        public virtual bool ModifyAccessRule(AccessControlModification modification,AccessRule rule, out bool modified) {
            return _fileSystemSecurity.ModifyAccessRule(modification, rule, out modified);
        }

        public virtual bool ModifyAuditRule(AccessControlModification modification,AuditRule rule, out bool modified) {
            return _fileSystemSecurity.ModifyAuditRule(modification, rule, out modified);
        }

        public virtual bool AreAccessRulesProtected {
            get { return _fileSystemSecurity.AreAccessRulesProtected; }
        }

        public virtual bool AreAuditRulesProtected {
            get { return _fileSystemSecurity.AreAuditRulesProtected; }
        }

        public virtual bool AreAccessRulesCanonical {
            get { return _fileSystemSecurity.AreAccessRulesCanonical; }
        }

        public virtual bool AreAuditRulesCanonical {
            get { return _fileSystemSecurity.AreAuditRulesCanonical; }
        }

        public virtual AuthorizationRuleCollection GetAccessRules(bool includeExplicit, bool includeInherited,Type targetType) {
            return _fileSystemSecurity.GetAccessRules(includeExplicit, includeInherited, targetType);
        }

        public virtual AuthorizationRuleCollection GetAuditRules(bool includeExplicit, bool includeInherited,Type targetType) {
            return _fileSystemSecurity.GetAuditRules(includeExplicit, includeInherited, targetType);
        }

        public virtual AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) {
            return _fileSystemSecurity.AccessRuleFactory(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
        }

        public virtual AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) {
            return _fileSystemSecurity.AuditRuleFactory(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
        }

        public virtual void AddAccessRule(FileSystemAccessRule rule) {
            _fileSystemSecurity.AddAccessRule(rule);
        }

        public virtual void SetAccessRule(FileSystemAccessRule rule) {
            _fileSystemSecurity.SetAccessRule(rule);
        }

        public virtual void ResetAccessRule(FileSystemAccessRule rule) {
            _fileSystemSecurity.ResetAccessRule(rule);
        }

        public virtual bool RemoveAccessRule(FileSystemAccessRule rule) {
            return _fileSystemSecurity.RemoveAccessRule(rule);
        }

        public virtual void RemoveAccessRuleAll(FileSystemAccessRule rule) {
            _fileSystemSecurity.RemoveAccessRuleAll(rule);
        }

        public virtual void RemoveAccessRuleSpecific(FileSystemAccessRule rule) {
            _fileSystemSecurity.RemoveAccessRuleSpecific(rule);
        }

        public virtual void AddAuditRule(FileSystemAuditRule rule) {
            _fileSystemSecurity.AddAuditRule(rule);
        }

        public virtual void SetAuditRule(FileSystemAuditRule rule) {
            _fileSystemSecurity.SetAuditRule(rule);
        }

        public virtual bool RemoveAuditRule(FileSystemAuditRule rule) {
            return _fileSystemSecurity.RemoveAuditRule(rule);
        }

        public virtual void RemoveAuditRuleAll(FileSystemAuditRule rule) {
            _fileSystemSecurity.RemoveAuditRuleAll(rule);
        }

        public virtual void RemoveAuditRuleSpecific(FileSystemAuditRule rule) {
            _fileSystemSecurity.RemoveAuditRuleSpecific(rule);
        }

        public virtual Type AccessRightType {
            get { return _fileSystemSecurity.AccessRightType; }
        }

        public virtual Type AccessRuleType {
            get { return _fileSystemSecurity.AccessRuleType; }
        }

        public virtual Type AuditRuleType {
            get { return _fileSystemSecurity.AuditRuleType; }
        }

        public FileSystemSecurity Security {
            get { return _fileSystemSecurity; }
        }
    }
}

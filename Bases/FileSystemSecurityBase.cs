using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using AshMind.IO.Abstractions.Security;

namespace AshMind.IO.Abstractions.Bases {
    public abstract class FileSystemSecurityBase : IFileSystemSecurity {
        public virtual IdentityReference GetOwner(Type targetType) {
            throw new NotImplementedException();
        }

        public virtual void SetOwner(IdentityReference identity) {
            throw new NotImplementedException();
        }

        public virtual IdentityReference GetGroup(Type targetType) {
            throw new NotImplementedException();
        }

        public virtual void SetGroup(IdentityReference identity) {
            throw new NotImplementedException();
        }

        public virtual void PurgeAccessRules(IdentityReference identity) {
            throw new NotImplementedException();
        }

        public virtual void PurgeAuditRules(IdentityReference identity) {
            throw new NotImplementedException();
        }

        public virtual void SetAccessRuleProtection(bool isProtected, bool preserveInheritance) {
            throw new NotImplementedException();
        }

        public virtual void SetAuditRuleProtection(bool isProtected, bool preserveInheritance) {
            throw new NotImplementedException();
        }

        public virtual string GetSecurityDescriptorSddlForm(AccessControlSections includeSections) {
            throw new NotImplementedException();
        }

        public virtual void SetSecurityDescriptorSddlForm(string sddlForm) {
            throw new NotImplementedException();
        }

        public virtual void SetSecurityDescriptorSddlForm(string sddlForm, AccessControlSections includeSections) {
            throw new NotImplementedException();
        }

        public virtual byte[] GetSecurityDescriptorBinaryForm() {
            throw new NotImplementedException();
        }

        public virtual void SetSecurityDescriptorBinaryForm(byte[] binaryForm) {
            throw new NotImplementedException();
        }

        public virtual void SetSecurityDescriptorBinaryForm(byte[] binaryForm, AccessControlSections includeSections) {
            throw new NotImplementedException();
        }

        public virtual bool ModifyAccessRule(AccessControlModification modification, AccessRule rule, out bool modified) {
            throw new NotImplementedException();
        }

        public virtual bool ModifyAuditRule(AccessControlModification modification, AuditRule rule, out bool modified) {
            throw new NotImplementedException();
        }

        public virtual bool AreAccessRulesProtected {
            get { throw new NotImplementedException(); }
        }

        public virtual bool AreAuditRulesProtected {
            get { throw new NotImplementedException(); }
        }

        public virtual bool AreAccessRulesCanonical {
            get { throw new NotImplementedException(); }
        }

        public virtual bool AreAuditRulesCanonical {
            get { throw new NotImplementedException(); }
        }

        public virtual Type AccessRightType {
            get { throw new NotImplementedException(); }
        }

        public virtual Type AccessRuleType {
            get { throw new NotImplementedException(); }
        }

        public virtual Type AuditRuleType {
            get { throw new NotImplementedException(); }
        }

        public virtual AuthorizationRuleCollection GetAccessRules(bool includeExplicit, bool includeInherited, Type targetType) {
            throw new NotImplementedException();
        }

        public virtual AuthorizationRuleCollection GetAuditRules(bool includeExplicit, bool includeInherited, Type targetType) {
            throw new NotImplementedException();
        }

        public virtual AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) {
            throw new NotImplementedException();
        }

        public virtual AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) {
            throw new NotImplementedException();
        }

        public virtual void AddAccessRule(FileSystemAccessRule rule) {
            throw new NotImplementedException();
        }

        public virtual void SetAccessRule(FileSystemAccessRule rule) {
            throw new NotImplementedException();
        }

        public virtual void ResetAccessRule(FileSystemAccessRule rule) {
            throw new NotImplementedException();
        }

        public virtual bool RemoveAccessRule(FileSystemAccessRule rule) {
            throw new NotImplementedException();
        }

        public virtual void RemoveAccessRuleAll(FileSystemAccessRule rule) {
            throw new NotImplementedException();
        }

        public virtual void RemoveAccessRuleSpecific(FileSystemAccessRule rule) {
            throw new NotImplementedException();
        }

        public virtual void AddAuditRule(FileSystemAuditRule rule) {
            throw new NotImplementedException();
        }

        public virtual void SetAuditRule(FileSystemAuditRule rule) {
            throw new NotImplementedException();
        }

        public virtual bool RemoveAuditRule(FileSystemAuditRule rule) {
            throw new NotImplementedException();
        }

        public virtual void RemoveAuditRuleAll(FileSystemAuditRule rule) {
            throw new NotImplementedException();
        }

        public virtual void RemoveAuditRuleSpecific(FileSystemAuditRule rule) {
            throw new NotImplementedException();
        }
    }
}

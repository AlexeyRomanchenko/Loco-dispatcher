﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGAT.locoDispatcher.ArchiveDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class arhieveEntities : DbContext
    {
        public arhieveEntities()
            : base("name=arhieveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aof> aof { get; set; }
        public virtual DbSet<ar_vag> ar_vag { get; set; }
        public virtual DbSet<arenda> arenda { get; set; }
        public virtual DbSet<bal_zurn> bal_zurn { get; set; }
        public virtual DbSet<dtproperties> dtproperties { get; set; }
        public virtual DbSet<dviz> dviz { get; set; }
        public virtual DbSet<GIR_Info> GIR_Info { get; set; }
        public virtual DbSet<gruz_v> gruz_v { get; set; }
        public virtual DbSet<gy_98> gy_98 { get; set; }
        public virtual DbSet<kontr_dviz> kontr_dviz { get; set; }
        public virtual DbSet<kontr_gruz> kontr_gruz { get; set; }
        public virtual DbSet<kontr_kr12> kontr_kr12 { get; set; }
        public virtual DbSet<kontr_kr91> kontr_kr91 { get; set; }
        public virtual DbSet<kontr_oper> kontr_oper { get; set; }
        public virtual DbSet<locomotiv> locomotiv { get; set; }
        public virtual DbSet<LokM_oper> LokM_oper { get; set; }
        public virtual DbSet<LokM_Work> LokM_Work { get; set; }
        public virtual DbSet<manevry> manevry { get; set; }
        public virtual DbSet<nal_park> nal_park { get; set; }
        public virtual DbSet<NNS_act_old> NNS_act_old { get; set; }
        public virtual DbSet<ob_train> ob_train { get; set; }
        public virtual DbSet<oper_tr> oper_tr { get; set; }
        public virtual DbSet<oper_v> oper_v { get; set; }
        public virtual DbSet<OSMOTR> OSMOTR { get; set; }
        public virtual DbSet<perev_SAP> perev_SAP { get; set; }
        public virtual DbSet<prikaz> prikaz { get; set; }
        public virtual DbSet<prikaz_vpu> prikaz_vpu { get; set; }
        public virtual DbSet<PV_dvizSAP> PV_dvizSAP { get; set; }
        public virtual DbSet<SMENA> SMENA { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tr2Pr_ish> tr2Pr_ish { get; set; }
        public virtual DbSet<train1> train1 { get; set; }
        public virtual DbSet<train2> train2 { get; set; }
        public virtual DbSet<VAG_KONT> VAG_KONT { get; set; }
        public virtual DbSet<vagon> vagon { get; set; }
        public virtual DbSet<vpu_spravka> vpu_spravka { get; set; }
        public virtual DbSet<vu14> vu14 { get; set; }
        public virtual DbSet<way_a> way_a { get; set; }
        public virtual DbSet<way_vag> way_vag { get; set; }
        public virtual DbSet<ZAJ_OTRAB> ZAJ_OTRAB { get; set; }
        public virtual DbSet<ZAJ_VAGON> ZAJ_VAGON { get; set; }
        public virtual DbSet<ZAJAVKA> ZAJAVKA { get; set; }
        public virtual DbSet<zajavka_por> zajavka_por { get; set; }
        public virtual DbSet<zajavka_por_vag> zajavka_por_vag { get; set; }
        public virtual DbSet<aof_cont> aof_cont { get; set; }
        public virtual DbSet<DO2> DO2 { get; set; }
        public virtual DbSet<dsp> dsp { get; set; }
        public virtual DbSet<dsp_info> dsp_info { get; set; }
        public virtual DbSet<DWH_oper> DWH_oper { get; set; }
        public virtual DbSet<DWH_service> DWH_service { get; set; }
        public virtual DbSet<gruz_v_ish> gruz_v_ish { get; set; }
        public virtual DbSet<har_s> har_s { get; set; }
        public virtual DbSet<kontr_DO2> kontr_DO2 { get; set; }
        public virtual DbSet<lok_perev> lok_perev { get; set; }
        public virtual DbSet<neisp_pko> neisp_pko { get; set; }
        public virtual DbSet<NEISPRAV_VAG> NEISPRAV_VAG { get; set; }
        public virtual DbSet<NNS_act_vag_old> NNS_act_vag_old { get; set; }
        public virtual DbSet<op_dop_info> op_dop_info { get; set; }
        public virtual DbSet<oper_kat_per> oper_kat_per { get; set; }
        public virtual DbSet<oper_v_kps> oper_v_kps { get; set; }
        public virtual DbSet<oper_way> oper_way { get; set; }
        public virtual DbSet<otpravka> otpravka { get; set; }
        public virtual DbSet<PADV_OTPR> PADV_OTPR { get; set; }
        public virtual DbSet<PADV_VPU_AOF> PADV_VPU_AOF { get; set; }
        public virtual DbSet<PADV_VPU_AOF_CKNIS> PADV_VPU_AOF_CKNIS { get; set; }
        public virtual DbSet<PADV_VPU_AOF_CKNIS_LOG> PADV_VPU_AOF_CKNIS_LOG { get; set; }
        public virtual DbSet<PADV_VPU_LOG> PADV_VPU_LOG { get; set; }
        public virtual DbSet<pam_vag> pam_vag { get; set; }
        public virtual DbSet<pametka> pametka { get; set; }
        public virtual DbSet<park_now> park_now { get; set; }
        public virtual DbSet<Pass_sostav> Pass_sostav { get; set; }
        public virtual DbSet<PASS_TR> PASS_TR { get; set; }
        public virtual DbSet<PROST> PROST { get; set; }
        public virtual DbSet<prost_for_st> prost_for_st { get; set; }
        public virtual DbSet<prost_vag> prost_vag { get; set; }
        public virtual DbSet<prost_vag_for_st> prost_vag_for_st { get; set; }
        public virtual DbSet<PTO_SAP> PTO_SAP { get; set; }
        public virtual DbSet<PV_dviz> PV_dviz { get; set; }
        public virtual DbSet<razl_kat> razl_kat { get; set; }
        public virtual DbSet<razl_kat_per> razl_kat_per { get; set; }
        public virtual DbSet<razl_nod> razl_nod { get; set; }
        public virtual DbSet<razl_osn> razl_osn { get; set; }
        public virtual DbSet<razl_pogr> razl_pogr { get; set; }
        public virtual DbSet<razl_rps> razl_rps { get; set; }
        public virtual DbSet<rem_smena> rem_smena { get; set; }
        public virtual DbSet<REZ_ZAP> REZ_ZAP { get; set; }
        public virtual DbSet<shift> shift { get; set; }
        public virtual DbSet<shift_employee> shift_employee { get; set; }
        public virtual DbSet<stat_info> stat_info { get; set; }
        public virtual DbSet<temp_Apiks_Stkass> temp_Apiks_Stkass { get; set; }
        public virtual DbSet<vu14_vag> vu14_vag { get; set; }
        public virtual DbSet<VZ_S_VAG_KONT> VZ_S_VAG_KONT { get; set; }
    }
}

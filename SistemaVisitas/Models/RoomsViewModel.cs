using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaVisitas.Models
{
    public class RoomsViewModel
    {
    }

    [Table("ENTRANCEROOM")]
    public partial class EntranceRoomViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntranceRoomViewModel()
        {
            REGISTROVISITAS = new HashSet<RegistroVisitasViewModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDER { get; set; }

        public double TEMPERATURA { get; set; }

        public bool LIMPAREA { get; set; }

        public bool RACK2_STATUS { get; set; }

        [StringLength(40)]
        public string RACK2_COMMENT { get; set; }

        public bool RACK3_STATUS { get; set; }

        [StringLength(40)]
        public string RACK3_COMMENT { get; set; }

        public bool RACK4_STATUS { get; set; }

        [StringLength(40)]
        public string RACK4_COMMENT { get; set; }

        public bool RACK5_STATUS { get; set; }

        [StringLength(40)]
        public string RACK5_COMMENT { get; set; }

        public bool EXTINTOR_STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroVisitasViewModel> REGISTROVISITAS { get; set; }
    }

    [Table("REGISTROVISITAS")]
    public partial class RegistroVisitasViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDREGISTRO { get; set; }

        [Required]
        [StringLength(100)]
        public string USERNAME { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FECHA { get; set; }

        public TimeSpan HORA_INICIO { get; set; }

        public TimeSpan HORA_FINAL { get; set; }

        public int IDER { get; set; }

        public int IDGR { get; set; }

        public int IDODC { get; set; }

        public int IDSR { get; set; }

        public int IDUPSA { get; set; }

        public int IDUPSB { get; set; }

        public virtual EntranceRoomViewModel ENTRANCEROOM { get; set; }

        public virtual GeneratorRoomViewModel GENERATORROOM { get; set; }

        public virtual OdcOfficeViewModel ODCOFFICE { get; set; }

        public virtual UPSAViewModel UPSA { get; set; }

        public virtual UPSBViewModel UPSB { get; set; }

        public virtual ServerRoomViewModel SERVERROOM { get; set; }
    }

    [Table("SERVERROOM")]
    public partial class ServerRoomViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServerRoomViewModel()
        {
            REGISTROVISITAS = new HashSet<RegistroVisitasViewModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDSR { get; set; }

        public bool RACK11_STATUS { get; set; }

        [StringLength(40)]
        public string RACK11_COMMENT { get; set; }

        public bool RACK12_STATUS { get; set; }

        [StringLength(40)]
        public string RACK12_COMMENT { get; set; }

        public bool RACK13_STATUS { get; set; }

        [StringLength(40)]
        public string RACK13_COMMENT { get; set; }

        public bool RACK14_STATUS { get; set; }

        [StringLength(40)]
        public string RACK14_COMMENT { get; set; }

        public bool RACK15_STATUS { get; set; }

        [StringLength(40)]
        public string RACK15_COMMENT { get; set; }

        public bool RACK16A_STATUS { get; set; }

        [StringLength(40)]
        public string RACK16A_COMMENT { get; set; }

        public bool RACK16B_STATUS { get; set; }

        [StringLength(40)]
        public string RACK16B_COMMENT { get; set; }

        public bool RACK25B_STATUS { get; set; }

        [StringLength(40)]
        public string RACK25B_COMMENT { get; set; }

        public bool RACK26B_STATUS { get; set; }

        [StringLength(40)]
        public string RACK26B_COMMENT { get; set; }

        public bool RACK29_STATUS { get; set; }

        [StringLength(40)]
        public string RACK29_COMMENT { get; set; }

        public bool RACK21_STATUS { get; set; }

        [StringLength(40)]
        public string RACK21_COMMENT { get; set; }

        public bool RACK22_STATUS { get; set; }

        [StringLength(40)]
        public string RACK22_COMMENT { get; set; }

        public bool RACK23_STATUS { get; set; }

        [StringLength(40)]
        public string RACK23_COMMENT { get; set; }

        public bool RACK24_STATUS { get; set; }

        [StringLength(40)]
        public string RACK24_COMMENT { get; set; }

        public bool RACK25A_STATUS { get; set; }

        [StringLength(40)]
        public string RACK25A_COMMENT { get; set; }

        public bool RACK26A_STATUS { get; set; }

        [StringLength(40)]
        public string RACK26A_COMMENT { get; set; }

        public bool RACK27_STATUS { get; set; }

        [StringLength(40)]
        public string RACK27_COMMENT { get; set; }

        public bool RACK28_STATUS { get; set; }

        [StringLength(40)]
        public string RACK28_COMMENT { get; set; }

        public bool LIMPAREA { get; set; }

        public bool PDUA_ALARMA { get; set; }

        public bool PDUA_LOG { get; set; }

        [Required]
        public double PDUA_POTENCIA { get; set; }

        [Required]
        public double PDUA_FRECUENCIA { get; set; }

        public bool PDUB_ALARMA { get; set; }

        public bool PDUB_LOG { get; set; }

        [Required]
        public double PDUB_POTENCIA { get; set; }

        [Required]
        public double PDUB_FRECUENCIA { get; set; }

        [Required]
        public double AC20_TEMP_ENTRADA { get; set; }

        [Required]
        public double AC20_TEMP_SALIDA { get; set; }

        [Required]
        public double AC20_HUMEDAD { get; set; }

        public bool AC20_ALARMA { get; set; }

        public bool AC5_LED { get; set; }

        [Required]
        public double AC5_TEMP_ENTRADA { get; set; }

        [Required]
        public double AC5_TEMP_SALIDA { get; set; }

        [Required]
        public double AC5_HUMEDAD { get; set; }

        public bool AC5_ALARMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroVisitasViewModel> REGISTROVISITAS { get; set; }
    }

    [Table("GENERATORROOM")]
    public partial class GeneratorRoomViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GeneratorRoomViewModel()
        {
            REGISTROVISITAS = new HashSet<RegistroVisitasViewModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDGR { get; set; }

        public double NIVEL_COMBUSTIBLE { get; set; }

        public bool PRUEBA_BOMBA { get; set; }

        public bool CONTACTOS_BATERIA { get; set; }

        public double CARGADOR_BATERIA { get; set; }

        public bool POSICION_BREAKERS { get; set; }

        public bool FUGA_ACEITE { get; set; }

        public bool TABLERO_G1 { get; set; }

        public bool TABLERO_G2 { get; set; }

        public bool EXTINTOR { get; set; }

        public bool DESAGUE_OBSTRUIDO { get; set; }

        public bool VALVULA_DESAGUE { get; set; }

        public bool VALVULA_TANQUES { get; set; }

        public double NIVEL_GASOIL { get; set; }

        public bool LETREROS { get; set; }

        public bool LIMPIEZA_GENERAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroVisitasViewModel> REGISTROVISITAS { get; set; }
    }

    [Table("ODCOFFICE")]
    public partial class OdcOfficeViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OdcOfficeViewModel()
        {
            REGISTROVISITAS = new HashSet<RegistroVisitasViewModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDODC { get; set; }

        public bool SMART_CAPACITY { get; set; }

        public bool AMBIENTE_DT { get; set; }

        public bool VEEAM_BC { get; set; }

        public bool VCENTER { get; set; }

        public bool BLADE_CENTER { get; set; }

        public bool NVR_EXT { get; set; }

        public bool NVR_INT { get; set; }

        public bool DVR_ODC { get; set; }

        public bool NETBOTZ { get; set; }

        public bool HMC { get; set; }

        public bool VIOS1 { get; set; }

        public bool VIOS2 { get; set; }

        public bool LIB_TL01 { get; set; }

        public bool LIB_TL02 { get; set; }

        public bool STRUXUREW { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroVisitasViewModel> REGISTROVISITAS { get; set; }
    }

    [Table("UPSA")]
    public partial class UPSAViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UPSAViewModel()
        {
            REGISTROVISITAS = new HashSet<RegistroVisitasViewModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUPSA { get; set; }

        public float TEMPERATURA { get; set; }

        public bool LIMPAREA { get; set; }

        public bool PANEL_VESDA { get; set; }

        public bool MANOMETRO_FM200 { get; set; }

        public bool PANEL_FM200 { get; set; }

        public bool LEDS_DVR { get; set; }

        public bool LEDS_NVR { get; set; }

        public bool POSICION_BREAKERS { get; set; }

        public bool EXTINTORES { get; set; }

        public float VOLTAJE_BYPASS { get; set; }

        public float AMPERAJE_BYPASS { get; set; }

        public double VOLTAJE_ENTRADA_L12 { get; set; }

        public double VOLTAJE_ENTRADA_L31 { get; set; }

        public double VOLTAJE_ENTRADA_L23 { get; set; }

        public double VOLTAJE_SALIDA_L12 { get; set; }

        public double VOLTAJE_SALIDA_L31 { get; set; }

        public double VOLTAJE_SALIDA_L23 { get; set; }

        public double FRECUENCIA_SALIDA { get; set; }

        public double POTENCIA_SALIDA { get; set; }

        public bool REVISION_LOG { get; set; }

        public bool ESTADO_SISTEMA { get; set; }

        public bool RACK1_STATUS { get; set; }

        [StringLength(40)]
        public string RACK1_COMMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroVisitasViewModel> REGISTROVISITAS { get; set; }
    }

    [Table("UPSB")]
    public partial class UPSBViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UPSBViewModel()
        {
            REGISTROVISITAS = new HashSet<RegistroVisitasViewModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUPSB { get; set; }

        public float TEMPERATURA { get; set; }

        public bool LIMPAREA { get; set; }

        public bool POSICION_BREAKERS { get; set; }


        public double VOLTAJE_BYPASS { get; set; }

        public double AMPERAJE_BYPASS { get; set; }

        public double VOLTAJE_ENTRADA_L12 { get; set; }

        public double VOLTAJE_ENTRADA_L31 { get; set; }

        public double VOLTAJE_ENTRADA_L23 { get; set; }

        public double VOLTAJE_SALIDA_L12 { get; set; }

        public double VOLTAJE_SALIDA_L31 { get; set; }

        public double VOLTAJE_SALIDA_L23 { get; set; }

        public double FRECUENCIA_SALIDA { get; set; }

        public double POTENCIA_SALIDA { get; set; }

        public bool REVISION_LOG { get; set; }

        public bool ESTADO_SISTEMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistroVisitasViewModel> REGISTROVISITAS { get; set; }
    }




    public partial class ReporteVisitaModelList { 
    
    
    public List<ReporteVisitaModel> DataList { get; set;        }
    
    }
    
    public partial class ReporteVisitaModel {


        public string Fecha { get; set; }

        public string Operador { get; set; }

       


    }







}
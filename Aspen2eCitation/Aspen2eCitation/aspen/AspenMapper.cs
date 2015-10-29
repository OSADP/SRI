using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace Aspen2eCitation.aspen
{
    class AspenMapper
    {
        public static Inspmain mapInspection(FbDataReader _reader) {
            Inspmain inspmain = new Inspmain();
            if (_reader.HasRows) {
                while (_reader.Read())
                {
                    inspmain.rptnum = _reader["rptnum"].ToString();
                    inspmain.accident = _reader["accident"].ToString();
                    inspmain.alcsubchk = _reader["alcsubchk"].ToString();
                    inspmain.aspen1 = _reader["aspen1"].ToString();
                    inspmain.aspen2 = _reader["aspen2"].ToString();
                    inspmain.aspenmatch = _reader["aspenmatch"].ToString();
                    inspmain.aspenversionnum = _reader["aspenversionnum"].ToString();
                    inspmain.axles = _reader["axles"].ToString();
                    inspmain.begfundedinspection = _reader["begfundedinspection"].ToString();
                    inspmain.begfundedtype = _reader["begfundedtype"].ToString();
                    inspmain.bipdverified = _reader["bipdverified"].ToString();
                    inspmain.cargo = _reader["cargo"].ToString();
                    inspmain.cargotankspecnum = _reader["cargotankspecnum"].ToString();
                    inspmain.carrcity = _reader["carrcity"].ToString();
                    inspmain.carrcolonia = _reader["carrcolonia"].ToString();
                    inspmain.carrcountry = _reader["carrcountry"].ToString();
                    inspmain.carrdbaname = _reader["carrdbaname"].ToString();
                    inspmain.carrfax = _reader["carrfax"].ToString();
                    inspmain.carrname = _reader["carrname"].ToString();
                    inspmain.carrphone = _reader["carrphone"].ToString();
                    inspmain.carrstate = _reader["carrstate"].ToString();
                    inspmain.carrstreet = _reader["carrstreet"].ToString();
                    inspmain.carrzipcode = _reader["carrzipcode"].ToString();

                    if (!(_reader["codriverdob"] is DBNull)) { 
                        inspmain.codriverdob = (DateTime)_reader["codriverdob"]; 
                    }
                    
                    inspmain.codriverfname = _reader["codriverfname"].ToString();
                    inspmain.codriverlicnum = _reader["codriverlicnum"].ToString();
                    inspmain.codriverlicstate = _reader["codriverlicstate"].ToString();
                    inspmain.codriverlname = _reader["codriverlname"].ToString();
                    inspmain.codrivermi = _reader["codrivermi"].ToString();
                    inspmain.coinspectorcode = _reader["coinspectorcode"].ToString();
                    inspmain.coinspectorname = _reader["coinspectorname"].ToString();
                    inspmain.destinationCity = _reader["destination_city"].ToString();
                    inspmain.destinationState = _reader["destination_state"].ToString();

                    if (!(_reader["driverdob"] is DBNull))
                    {
                        inspmain.driverdob = (DateTime)_reader["driverdob"];
                    }

                    inspmain.driverfname = _reader["driverfname"].ToString();
                    inspmain.driverlicnum = _reader["driverlicnum"].ToString();
                    inspmain.driverlicstate = _reader["driverlicstate"].ToString();
                    inspmain.driverlname = _reader["driverlname"].ToString();
                    inspmain.drivermi = _reader["drivermi"].ToString();
                    inspmain.driveroos = _reader["driveroos"].ToString();

                    if (!(_reader["driversignature"] is DBNull))
                    {
                        inspmain.driversignature = (byte[])_reader["driversignature"];
                    }

                    inspmain.drugarrest = _reader["drugarrest"].ToString();
                    inspmain.drugsearch = _reader["drugsearch"].ToString();

                    if (!(_reader["duration"] is DBNull))
                    {
                        inspmain.duration = (Int32)_reader["duration"];
                    }

                    inspmain.escreen = _reader["escreen"].ToString();
                    inspmain.facilitytype = _reader["facilitytype"].ToString();
                    inspmain.fipscountycode = _reader["fipscountycode"].ToString();

                    if (!(_reader["gcwr"] is DBNull))
                    {
                        inspmain.gcwr = (Int32)_reader["gcwr"];
                    }

                    inspmain.highway = _reader["highway"].ToString();
                    inspmain.hminsptype = _reader["hminsptype"].ToString();
                    inspmain.hmplacard = _reader["hmplacard"].ToString();
                    inspmain.iccnum = _reader["iccnum"].ToString();
                    inspmain.ieppretripinspection = _reader["ieppretripinspection"].ToString();
                    inspmain.ieppretripspace = _reader["ieppretripspace"].ToString();
                    inspmain.inspcountry = _reader["inspcountry"].ToString();
                    inspmain.inspcounty = _reader["inspcounty"].ToString();
                    inspmain.inspectorcode = _reader["inspectorcode"].ToString();
                    inspmain.inspectorname = _reader["inspectorname"].ToString();

                    if (!(_reader["inspenddate"] is DBNull))
                    {
                        inspmain.inspenddate = (DateTime)_reader["inspenddate"];
                    }

                    if (!(_reader["inspendtime"] is DBNull))
                    {
                        inspmain.inspendtime = (TimeSpan)_reader["inspendtime"];
                    }

                    inspmain.insplocationcode = _reader["insplocationcode"].ToString();
                    inspmain.insplocationdesc = _reader["insplocationdesc"].ToString();

                    if (!(_reader["inspstartdate"] is DBNull))
                    {
                        inspmain.inspstartdate = (DateTime)_reader["inspstartdate"];
                    }

                    if (!(_reader["inspstarttime"] is DBNull))
                    {
                        inspmain.inspstarttime = (TimeSpan)_reader["inspstarttime"];
                    }

                    inspmain.inspstate = _reader["inspstate"].ToString();
                    inspmain.interstate = _reader["interstate"].ToString();
                    inspmain.level = _reader["level"].ToString();
                    inspmain.localjurisdiction = _reader["localjurisdiction"].ToString();
                    inspmain.manualCarrierIsOos = _reader["manual_carrier_is_oos"].ToString();
                    inspmain.manualCarrierNoOpAuth = _reader["manual_carrier_no_op_auth"].ToString();
                    inspmain.manualOosCheckMethod = _reader["manual_oos_check_method"].ToString();
                    inspmain.manualOosOperAuthCheck = _reader["manual_oos_oper_auth_check"].ToString();
                    inspmain.mexicancarrierid = _reader["mexicancarrierid"].ToString();
                    inspmain.milepost = _reader["milepost"].ToString();
                    inspmain.notes = _reader["notes"].ToString();
                    inspmain.oosuntil = _reader["oosuntil"].ToString();
                    inspmain.originCity = _reader["origin_city"].ToString();
                    inspmain.originState = _reader["origin_state"].ToString();
                    inspmain.pasainspection = _reader["pasainspection"].ToString();
                    inspmain.pbbtaxles = _reader["pbbtaxles"].ToString();

                    if (!(_reader["pbbtbrakeforce"] is DBNull))
                    {
                        inspmain.pbbtbrakeforce = (Double)_reader["pbbtbrakeforce"];
                    }

                    inspmain.pbbtcheck = _reader["pbbtcheck"].ToString();
                    
                    if (!(_reader["pbbtminbrakeforce"] is DBNull))
                    {
                        inspmain.pbbtminbrakeforce = (Double)_reader["pbbtminbrakeforce"];
                    }

                    if (!(_reader["pbbtvehicletypeid"] is DBNull))
                    {
                        inspmain.pbbtvehicletypeid = (short)_reader["pbbtvehicletypeid"];
                    }

                    inspmain.rptstatus = _reader["rptstatus"].ToString();
                    inspmain.shipname = _reader["shipname"].ToString();
                    inspmain.shipnum = _reader["shipnum"].ToString();
                    inspmain.sizeweightenf = _reader["sizeweightenf"].ToString();
                    inspmain.statecensusnum = _reader["statecensusnum"].ToString();
                    inspmain.statecountycode = _reader["statecountycode"].ToString();
                    inspmain.study1 = _reader["study1"].ToString();
                    inspmain.study10 = _reader["study10"].ToString();
                    inspmain.study2 = _reader["study2"].ToString();
                    inspmain.study3 = _reader["study3"].ToString();
                    inspmain.study4 = _reader["study4"].ToString();
                    inspmain.study5 = _reader["study5"].ToString();
                    inspmain.study6 = _reader["study6"].ToString();
                    inspmain.study7 = _reader["study7"].ToString();
                    inspmain.study8 = _reader["study8"].ToString();
                    inspmain.study9 = _reader["study9"].ToString();
                    inspmain.tag = _reader["tag"].ToString();
                    inspmain.timezone = _reader["timezone"].ToString();
                    inspmain.totaldriveroosvio = _reader["totaldriveroosvio"].ToString();
                    inspmain.totalhm = _reader["totalhm"].ToString();
                    inspmain.totaloosvio = _reader["totaloosvio"].ToString();
                    inspmain.totalvehicle = _reader["totalvehicle"].ToString();
                    inspmain.totalvehicleoosvio = _reader["totalvehicleoosvio"].ToString();
                    inspmain.totalvio = _reader["totalvio"].ToString();
                    inspmain.trafficenf = _reader["trafficenf"].ToString();

                    if (!(_reader["trandate"] is DBNull))
                    {
                        inspmain.trandate = (DateTime)_reader["trandate"];
                    }

                    if (!(_reader["trantime"] is DBNull))
                    {
                        inspmain.trantime = (TimeSpan)_reader["trantime"];
                    }

                    inspmain.transferred = _reader["transferred"].ToString();

                    inspmain.unit1platenum = _reader["unit1platenum"].ToString();
                    inspmain.usdotnum = _reader["usdotnum"].ToString();
                    inspmain.vehicleoos = _reader["vehicleoos"].ToString();

                    // Get the vehicle
                    inspmain.vehicle = mapVehicle(_reader);

                }
            }

            return inspmain;

        }

        public static Vehicle mapVehicle(FbDataReader _reader)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.rptnum = _reader["rptnum"].ToString();
            vehicle.unitnum = _reader["unitnum"].ToString();
            vehicle.cargosealremovedid = _reader["cargosealremovedid"].ToString();
            vehicle.cargosealreplacedid = _reader["cargosealreplacedid"].ToString();
            vehicle.cvsadecal = _reader["cvsadecal"].ToString();
            vehicle.decalnum = _reader["decalnum"].ToString();
            vehicle.existingdecalnum = _reader["existingdecalnum"].ToString();
            vehicle.existingdecalstatus = _reader["existingdecalstatus"].ToString();
            vehicle.iepchassispool = _reader["iepchassispool"].ToString();
            vehicle.iepdatasource = _reader["iepdatasource"].ToString();

            if (!(_reader["trandate"] is DBNull))
            {
                vehicle.ieplookuptimestamp = (DateTime)_reader["trandate"];
            }

            vehicle.iepname = _reader["iepname"].ToString();
            vehicle.iepusdotnum = _reader["iepusdotnum"].ToString();
            vehicle.oosnum = _reader["oosnum"].ToString();
            vehicle.unitconum = _reader["unitconum"].ToString();

            if (!(_reader["unitgvwr"] is DBNull))
            {
                vehicle.unitgvwr = (Int32)_reader["unitgvwr"];
            }
            
            vehicle.unitlicnum = _reader["unitlicnum"].ToString();
            vehicle.unitlicstate = _reader["unitlicstate"].ToString();
            vehicle.unitmake = _reader["unitmake"].ToString();
            vehicle.unittype = _reader["unittype"].ToString();
            vehicle.unitvin = _reader["unitvin"].ToString();
            vehicle.unityear = _reader["unityear"].ToString();

            return vehicle;
        }
    }
}

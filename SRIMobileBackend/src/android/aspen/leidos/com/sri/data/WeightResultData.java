
package android.aspen.leidos.com.sri.data;
//
// This file was generated by the BinaryNotes compiler.
// See http://bnotes.sourceforge.net 
// Any modifications to this file will be lost upon recompilation of the source ASN.1. 
//

import org.bn.*;
import org.bn.annotations.*;
import org.bn.annotations.constraints.*;
import org.bn.coders.*;
import org.bn.types.*;




    @ASN1PreparedElement
    @ASN1Sequence ( name = "WeightResultData", isSet = false )
    public class WeightResultData implements IASN1PreparedElement {
            
    @ASN1String( name = "", 
        stringType = UniversalTag.UTF8String , isUCS = false )
    
        @ASN1Element ( name = "id", isOptional =  false , hasTag =  true, tag = 0 , hasDefaultValue =  false  )
    
	private String id = null;
                
  
    @ASN1String( name = "", 
        stringType = UniversalTag.UTF8String , isUCS = false )
    
        @ASN1Element ( name = "siteId", isOptional =  false , hasTag =  true, tag = 1 , hasDefaultValue =  false  )
    
	private String siteId = null;
                
  
        @ASN1Element ( name = "fullDate", isOptional =  false , hasTag =  true, tag = 2 , hasDefaultValue =  false  )
    
	private DDateTime fullDate = null;
                
  
    @ASN1String( name = "", 
        stringType = UniversalTag.UTF8String , isUCS = false )
    
        @ASN1Element ( name = "weightResult", isOptional =  false , hasTag =  true, tag = 3 , hasDefaultValue =  false  )
    
	private String weightResult = null;
                
  
        
        public String getId () {
            return this.id;
        }

        

        public void setId (String value) {
            this.id = value;
        }
        
  
        
        public String getSiteId () {
            return this.siteId;
        }

        

        public void setSiteId (String value) {
            this.siteId = value;
        }
        
  
        
        public DDateTime getFullDate () {
            return this.fullDate;
        }

        

        public void setFullDate (DDateTime value) {
            this.fullDate = value;
        }
        
  
        
        public String getWeightResult () {
            return this.weightResult;
        }

        

        public void setWeightResult (String value) {
            this.weightResult = value;
        }
        
  
                    
        
        public void initWithDefaults() {
            
        }

        private static IASN1PreparedElementData preparedData = CoderFactory.getInstance().newPreparedElementData(WeightResultData.class);
        public IASN1PreparedElementData getPreparedData() {
            return preparedData;
        }

            
    }
            
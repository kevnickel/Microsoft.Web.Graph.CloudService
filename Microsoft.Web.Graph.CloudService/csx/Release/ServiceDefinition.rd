<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Microsoft.Web.Graph.CloudService" generation="1" functional="0" release="0" Id="3267bb07-fa73-4a09-bb6f-21c020759586" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Microsoft.Web.Graph.CloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Microsoft.Web.Graph.WebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/LB:Microsoft.Web.Graph.WebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|Microsoft.Web.Graph.WebRole:Front Door Client Cert" defaultValue="">
          <maps>
            <mapMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/MapCertificate|Microsoft.Web.Graph.WebRole:Front Door Client Cert" />
          </maps>
        </aCS>
        <aCS name="Certificate|Microsoft.Web.Graph.WebRole:SSL EndPoint" defaultValue="">
          <maps>
            <mapMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/MapCertificate|Microsoft.Web.Graph.WebRole:SSL EndPoint" />
          </maps>
        </aCS>
        <aCS name="Microsoft.Web.Graph.WebRole:APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="">
          <maps>
            <mapMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/MapMicrosoft.Web.Graph.WebRole:APPINSIGHTS_INSTRUMENTATIONKEY" />
          </maps>
        </aCS>
        <aCS name="Microsoft.Web.Graph.WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/MapMicrosoft.Web.Graph.WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="Microsoft.Web.Graph.WebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/MapMicrosoft.Web.Graph.WebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Microsoft.Web.Graph.WebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapCertificate|Microsoft.Web.Graph.WebRole:Front Door Client Cert" kind="Identity">
          <certificate>
            <certificateMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole/Front Door Client Cert" />
          </certificate>
        </map>
        <map name="MapCertificate|Microsoft.Web.Graph.WebRole:SSL EndPoint" kind="Identity">
          <certificate>
            <certificateMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole/SSL EndPoint" />
          </certificate>
        </map>
        <map name="MapMicrosoft.Web.Graph.WebRole:APPINSIGHTS_INSTRUMENTATIONKEY" kind="Identity">
          <setting>
            <aCSMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole/APPINSIGHTS_INSTRUMENTATIONKEY" />
          </setting>
        </map>
        <map name="MapMicrosoft.Web.Graph.WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapMicrosoft.Web.Graph.WebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Microsoft.Web.Graph.WebRole" generation="1" functional="0" release="0" software="E:\UniversalHeader\Microsoft.Web.Graph\Microsoft.Web.Graph\Microsoft.Web.Graph.CloudService\Microsoft.Web.Graph.CloudService\csx\Release\roles\Microsoft.Web.Graph.WebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Microsoft.Web.Graph.WebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Microsoft.Web.Graph.WebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Front Door Client Cert" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole/Front Door Client Cert" />
                </certificate>
              </storedCertificate>
              <storedCertificate name="Stored1SSL EndPoint" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole/SSL EndPoint" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Front Door Client Cert" />
              <certificate name="SSL EndPoint" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="Microsoft.Web.Graph.WebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="Microsoft.Web.Graph.WebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Microsoft.Web.Graph.WebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="c5a001bf-e1c2-4b47-84be-5fa65a041003" ref="Microsoft.RedDog.Contract\ServiceContract\Microsoft.Web.Graph.CloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="3d3107b7-610a-410e-8d30-61eab9a0e7fa" ref="Microsoft.RedDog.Contract\Interface\Microsoft.Web.Graph.WebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Microsoft.Web.Graph.CloudService/Microsoft.Web.Graph.CloudServiceGroup/Microsoft.Web.Graph.WebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>
@description('Specifies the location for resources.')
param location string
@description('Specifies the name for the resourcegroup.')
param resourcegroupname string

// Setting target scope
targetScope = 'subscription'

// Creating resource group
resource rg 'Microsoft.Resources/resourceGroups@2021-01-01' = {
  name: resourcegroupname
  location: location
}

// Deploying function app using module
module fcn './function.bicep' = {
  name: 'functionDeployment'
  scope: rg    // Deployed in the scope of resource group we created above
  params: {
    location: location
    appInsightsLocation: location
  }
}

@allowed([
  'dev'
  'uat'
  'prod'
])
param deployEnvironment string
param location string 

var appEnvironments = {
  dev: 'Development'
  uat: 'Staging'
  prod: 'Production'
}

// Can use existing resources inside of scope (default is the resource group), or go out of scope with a little extra work.
resource appServicePlan 'Microsoft.Web/serverfarms@2021-03-01' existing = {
  name: 'appserviceplan'
  scope: resourceGroup('${deployEnvironment}-resource-group')
}

// Can set conditionals based on environment. Conditionals can be used in most places.
resource appInsights 'Microsoft.Insights/components@2020-02-02' = if(deployEnvironment == 'prod') {
  name: 'MyApplicationInsights'
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
}

module keyVault 'keyVault.bicep' = {
  name: uniqueString(resourceGroup().id)
  params:{
    accountingItSubnet: 
  }
}

// Access outputs via dot notation.
var keyVaultName = keyVault.outputs.name

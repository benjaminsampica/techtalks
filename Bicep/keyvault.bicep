param deployEnvironment string
param appName string
param location string
param caseysInternalIpAddress string
param accountingItSubnet string
param keyVaultAccessObjectIds array
@secure()
param connectionStringsCreditCard string

resource keyVault 'Microsoft.KeyVault/vaults@2021-10-01' = {
  name: '${deployEnvironment}-ncus-${appName}-kv-01'
  location: location 
  properties: {
    enabledForDeployment: true
    enabledForTemplateDeployment: true
    enabledForDiskEncryption: true
    enablePurgeProtection: true
    tenantId: subscription().tenantId
    sku: {
      family: 'A'
      name: 'standard'
    }
    networkAcls: {
        bypass: 'AzureServices'
        defaultAction: 'Deny'
        ipRules: [
          {
            value: '${caseysInternalIpAddress}/32'
          }
        ]
        virtualNetworkRules: [
          {
            id: accountingItSubnet
          }
        ]
    }
    // Iterate over a dynamic number of objects
    accessPolicies: [for accessPolicyGroupId in keyVaultAccessObjectIds: {
      tenantId: subscription().tenantId
      objectId: accessPolicyGroupId
      permissions: {
        keys: [
          'all'
        ]
        secrets: [
          'all'
        ]
        certificates: [
          'all'
        ]
      }
    }]
  }

  // nest resources inside of each other.
  resource connectionStringsCreditCardSecret 'secrets' = {
    name: 'ConnectionStringsCreditCard'
    properties: {
      value: connectionStringsCreditCard
    }
  }
}

output name string = keyVault.name

import Vue from 'vue'; //import Vue if you want to use the framework.globalMixin option
import MSAL from 'vue-msal/lib/plugin';

import { Plugin } from '@nuxt/types'
import { MSALBasic, DataObject } from 'vue-msal/lib/src/types';
import { userStore } from '~/store';
import { IUserModel } from '~/store/userModule';

declare module '@nuxt/types' {
  interface NuxtAppOptions {
    $msal: MSALBasic,
  }
}
declare module 'vue/types/vue' {
  interface Vue {
    $msal: MSALBasic,
  }
}

const scopes = process.env.adScopes!.split(/,/g);

const myPlugin: Plugin = (context, inject) => {

  inject('msal', new MSAL(
    {
      auth: {
        clientId: process.env.adClientId!,
        tenantId: process.env.adTenantId!,
        onAuthentication: (ctx, error, response) => {
          userStore.sigoutUser();
        },
        onToken: (ctx, error, response) => {
          const msal = ctx as MSALBasic;
          userStore.siginUser(msal);
        },
        beforeSignOut: (ctx) => {
          userStore.sigoutUser();
        }
      },
      request: {
        scopes
      }
    }, Vue /* [optional] should be passed as an argument if you want to the framework.globalMixin option*/
  ))
}

export default myPlugin

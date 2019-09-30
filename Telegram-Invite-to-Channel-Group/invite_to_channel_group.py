#!/usr/bin/env python3
# -*- coding: utf-8 -*-

# Scripts inviting members 
#
# By @CodyDoby 
# Telegram Group: https://t.me/google_dive
# Blog: https://gfan.loan/
#

from telethon import TelegramClient, sync, errors
from telethon.errors import SessionPasswordNeededError

from telethon.tl.functions.account import UpdateProfileRequest
from telethon.tl.functions.messages import AddChatUserRequest
from telethon.tl.functions.channels import InviteToChannelRequest
from telethon.tl.types import PeerUser, PeerChat, PeerChannel

import python3pickledb as pickledb

from time import gmtime, strftime
import time, sys
import os.path
import random

#Need change those api to yours
c_info = {
'c0': ('cody_client1', 388159, 'b6337b1e003b7eax780fd2d77f7e0478'),
'c1': ('cody_client2', 1083515, '7e1da0642d08772e6f9663c64e71434f')
#'c3': ('cody_client5', 144783, 'bccb20ef33c1ccfc2ac18c9f3db7f30c'),
#'c4': ('cody_client5', 135843, '777bebb1fd9b98eb2980fd1e7c3de9ab')

}

if c_info['c0'][1] == 388158:
   sys.exit('Need change api to yours')

sour = 'https://t.me/tinhieu_pro_bogg'
dest = 'https://t.me/monster_BO'

clients = {}
dests = {}
all_participants = {}

for key, value in c_info.items():
   print('>> client %s creating' % key)

   clients[key] = TelegramClient(*value)
   clients[key].start()

   print('>>>> client %s created' % key)

   dests[key] = clients[key].get_entity(dest)
   all_participants[key] = clients[key].get_participants(sour, aggressive=True)

print('Works!')

db = pickledb.load('clientbot_test.db', True)
 
ind = 0
if not db.get('start'):
    db.set('start', ind)
else:
    ind = int(db.get('start'))
    print('Start from ', ind) 

while True:
        users = {}
        for key, value in all_participants.items():
            users[key] = value[ind]

        for key, value in users.items():
            if value == None: 
               sys.exit('All members (%d) done' % ind)
        rd_ind = random.sample(list(clients.keys()), len(clients))[0]
        print('>>>> client %s works' % rd_ind)

        client = clients[rd_ind]
        dest = dests[rd_ind]
        user = users[rd_ind]
        
        try:
            client(InviteToChannelRequest(
                dest,
                [user],
            ))

            print("%-6d: %-9d | @%s | %s | %s | Done" % (ind, user.id, user.username, user.first_name, user.last_name))

        except errors.rpcerrorlist.UserPrivacyRestrictedError:
            print('>>>>0. UserPrivacyRestrictedError...')
        except errors.rpcerrorlist.ChatAdminRequiredError:
            print('>>>>1. ChatAdminRequiredError...')
        except errors.rpcerrorlist.ChatIdInvalidError:
            print('>>>>2. ChatIdInvalidError...')
        except errors.rpcerrorlist.InputUserDeactivatedError:
            print('>>>>3. InputUserDeactivatedError...')
        except errors.rpcerrorlist.PeerIdInvalidError:
            print('>>>>4. PeerIdInvalidError...')
        except errors.rpcerrorlist.UserAlreadyParticipantError:
            print('>>>>5. UserAlreadyParticipantError...')
        except errors.rpcerrorlist.UserIdInvalidError:
            print('>>>>6. UserIdInvalidError...')
        except errors.rpcerrorlist.UserNotMutualContactError:
            print('>>>>>7. UserNotMutualContactError...')
        except errors.rpcerrorlist.UsersTooMuchError:
            print('>>>>>8. UsersTooMuchError...')
        except errors.rpcerrorlist.PeerFloodError:
            ind -= 1
            print('>>>>>9. PeerFloodError try again in 2 Mins...')
            time.sleep(120)

        # CPU sleep 
        time.sleep(random.randint(60, 180))
        ind += 1
        db.set('start', ind)

## 1. No events in shared classes.

Since the shared classes are used by both the server and the client, and
it is expected that in the locally-bridged case we will have an active
server and an active client in the same process, events introduce logical
complexity that is better avoided than tip-toed around.
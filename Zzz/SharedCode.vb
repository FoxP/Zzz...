'-----------------------------------------------------------------------------------------------------------------------------------------------
'
'	This program is free software; you can redistribute it and/or
'	modify it under the terms of the GNU General Public License
'	as published by the Free Software Foundation; either version 2
'	of the License, or (at your option) any later version.
'
'	This program is distributed in the hope that it will be useful,
'	but WITHOUT ANY WARRANTY; without even the implied warranty of
'	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'	GNU General Public License for more details.
'
'	You should have received a copy of the GNU General Public License
'	along with this program; if not, write to the Free Software Foundation,
'	Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
'
'	Name :
'				Zzz...
'	Author :
'				▄▄▄▄▄▄▄  ▄ ▄▄ ▄▄▄▄▄▄▄
'				█ ▄▄▄ █ ██ ▀▄ █ ▄▄▄ █
'				█ ███ █ ▄▀ ▀▄ █ ███ █
'				█▄▄▄▄▄█ █ ▄▀█ █▄▄▄▄▄█
'				▄▄ ▄  ▄▄▀██▀▀ ▄▄▄ ▄▄
'				 ▀█▄█▄▄▄█▀▀ ▄▄▀█ █▄▀█
'				 █ █▀▄▄▄▀██▀▄ █▄▄█ ▀█
'				▄▄▄▄▄▄▄ █▄█▀ ▄ ██ ▄█
'				█ ▄▄▄ █  █▀█▀ ▄▀▀  ▄▀
'				█ ███ █ ▀▄  ▄▀▀▄▄▀█▀█
'				█▄▄▄▄▄█ ███▀▄▀ ▀██ ▄
'
'-----------------------------------------------------------------------------------------------------------------------------------------------

Module SharedCode

    'Run hidden Windows command line processes with argument(s)
    Sub startHiddenProcess(ByVal sCommand As String, ByVal sArgs As String)
        Dim p As New ProcessStartInfo(sCommand, sArgs)
        p.WindowStyle = ProcessWindowStyle.Hidden
        p.CreateNoWindow = True
        Process.Start(p)
    End Sub

    'Hibernate computer
    Sub hibernate()
        Call startHiddenProcess("Shutdown", "-h")
    End Sub

    'Shutdown computer
    Sub shutdown()
        Call startHiddenProcess("Shutdown", "-s -f")
    End Sub

    'Reboot computer
    Sub reboot()
        Call startHiddenProcess("Shutdown", "-r -f")
    End Sub

    'Log off user
    Sub logOff()
        Call startHiddenProcess("Shutdown", "-l -f")
    End Sub

    'Abort shutdown / reboot
    Sub cancelShutdown()
        Call startHiddenProcess("Shutdown", "-a")
    End Sub

End Module

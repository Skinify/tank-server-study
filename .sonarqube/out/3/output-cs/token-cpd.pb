û
EO:\Repositorios\TankTankTeste\TankTankTeste.Databases.Game\Context.cs
	namespace 	
TankTankTeste
 
. 
	Databases !
.! "
Tank" &
{ 
public 

class 
TankContext 
: 
	DbContext (
{ 
public 
TankContext 
( 
DbContextOptions +
<+ ,
TankContext, 7
>7 8
options9 @
)@ A
:		 
base		 
(		 
options		 !
)		! "
{

 	
} 	
public 
DbSet 
< 
UserInfo 
> 
UserInfo '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
} 	
} 
} õ
VO:\Repositorios\TankTankTeste\TankTankTeste.Databases.Game\Models\Entities\UserInfo.cs
	namespace 	
TankTankTeste
 
. 
	Databases !
.! "
Tank" &
.& '
Models' -
.- .
Entities. 6
{ 
[ 
Table 

(
 
$str 
, 
Schema 
= 
$str  &
)& '
]' (
public 

class 
UserInfo 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
=		) *
null		+ /
!		/ 0
;		0 1
}

 
} ª	
YO:\Repositorios\TankTankTeste\TankTankTeste.Databases.Game\Repositories\UserRepository.cs
	namespace 	
Tank
 
. 
Repositories 
{ 
public 

class 
UserRepository 
:  !
BaseRepository" 0
<0 1
UserInfo1 9
>9 :
,: ;
IUserRepository< K
{		 
private

 
readonly

 
TankContext

 $
_tankContext

% 1
;

1 2
public 
UserRepository 
( 
TankContext )
tankContext* 5
)5 6
:7 8
base9 =
(= >
tankContext> I
)I J
{ 	
_tankContext 
= 
tankContext &
;& '
} 	
public 
Task 
< 

IQueryable 
< 
UserInfo '
>' (
>( )
GetAll* 0
(0 1
)1 2
{ 	
throw 
new #
NotImplementedException -
(- .
). /
;/ 0
} 	
} 
} è
eO:\Repositorios\TankTankTeste\TankTankTeste.Databases.Game\Repositories\_Interface\IUserRepository.cs
	namespace 	
Tank
 
. 
Repositories 
. 

_Interface &
{ 
public 

	interface 
IUserRepository $
:$ %
IBaseRepository& 5
<5 6
UserInfo6 >
>> ?
{ 
public 
Task 
< 

IQueryable 
< 
UserInfo '
>' (
>( )
GetAll* 0
(0 1
)1 2
;2 3
}		 
}

 æ
gO:\Repositorios\TankTankTeste\TankTankTeste.Databases.Game\Repositories\_Mocked\MockedUserRepository.cs
	namespace 	
Tank
 
. 
Repositories 
. 
_Mocked #
{ 
public 

class  
MockedUserRepository %
:& ' 
BaseMockedRepository( <
<< =
UserInfo= E
>E F
,F G
IUserRepositoryH W
{ 
private		 
readonly		 
IList		 
<		 
UserInfo		 '
>		' (
_users		) /
;		/ 0
public

  
MockedUserRepository

 #
(

# $
)

$ %
{ 	
_users 
= 
new 
List 
< 
UserInfo &
>& '
{ 
new 
UserInfo 
( 
) 
, 
new 
UserInfo 
( 
) 
, 
new 
UserInfo 
( 
) 
} 
; 
} 	
public 
Task 
< 

IQueryable 
< 
UserInfo '
>' (
>( )
GetAll* 0
(0 1
)1 2
{ 	
return 
Task 
. 

FromResult "
(" #
_users# )
.) *
AsQueryable* 5
(5 6
)6 7
)7 8
;8 9
} 	
} 
} 
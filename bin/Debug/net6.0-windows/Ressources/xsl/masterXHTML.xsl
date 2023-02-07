<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY nbsp "&#160;">
]>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" xmlns:fo="http://www.w3.org/1999/XSL/Format" exclude-result-prefixes="fo">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	<!--global configuration-->
	<xsl:param name="outputType">
		<xsl:choose>
			<xsl:when test="/photos/config/output">
				<xsl:value-of select="/photos/config/output"/>
			</xsl:when>
			<xsl:otherwise>xml</xsl:otherwise>
		</xsl:choose>
	</xsl:param>
	<xsl:param name="defaultUnit">mm</xsl:param>
	<!--paper configuration-->
	<xsl:param name="paperWidth" select="210"/>
	<xsl:param name="paperHeight" select="297"/>
	<!--page configuration-->
	<xsl:param name="tableCols" select="/photos/config/cols"/>
	<xsl:param name="tableRows" select="/photos/config/rows"/>
	<!--inherit configuration-->
	<xsl:variable name="imageEachPages" select="$tableCols * $tableRows"/>
	<xsl:variable name="colWidth" select="$paperWidth div $tableCols"/>
	<xsl:variable name="rowHeight" select="$paperHeight div $tableRows"/>
	<xsl:template match="/">
		<xsl:call-template name="html-main"/>
	</xsl:template>
	<xsl:template name="html-main">
		<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fr">
			<head>
				<title>
					<xsl:value-of select="/photos/title"/>
				</title>
				<style type="text/css">
				.page{
					background-image:<xsl:choose>
						<xsl:when test="/photos/config/image">url(<xsl:value-of select="concat(/photos/config/image/@path,/photos/config/image/@href)"/>)</xsl:when>
						<xsl:otherwise>none</xsl:otherwise>
					</xsl:choose>;
							text-align:center;
				}
				.photo-container{
					 text-align:center;
					 padding-top:0.5mm;
				}
				@media screen{
					.page{
						width:98vw;
					}
					.intercal{
						display:none;
					}
					.page .photo{
						max-height:33vh;
					}
					.page .photos-table{
						 width:100%;
					} 
					.page .photos-table-td{
						width:<xsl:value-of select=" 99 div $tableCols"/>vw;
						border: 1px solid black;
					}
				}
				@media print{
					#pages .page:not(:first-child){
						page-break-before:always;
					}
					.page{
						height:<xsl:value-of select="concat($paperHeight,$defaultUnit)"/>;
						width:<xsl:value-of select="concat($paperWidth,$defaultUnit)"/>;
					}
					.page .photo{
						/*scaling="uniform" content-height="{concat((($rowHeight - 0.5)*0.9),$defaultUnit)}" content-width="{concat(($colWidth - 1),$defaultUnit)}*/
					}
					.page .photos-table{
						 width:<xsl:value-of select="concat($paperWidth,$defaultUnit)"/>;
					}
					.page .photos-table-tr{
						 height:<xsl:value-of select="concat($rowHeight,$defaultUnit)"/>;
					}
					.page .photos-table-td{
						width:<xsl:value-of select="concat($colWidth,$defaultUnit)"/>;
						border: 0.5mm solid black;
					}
					.page .photo-container'
					{
						width:100%;
						height:<xsl:value-of select="concat($paperHeight div $rowHeight,$defaultUnit)"/>
					}
					.page .photo{
							/*max-height:calc(100% - 1cm);
							max-width: 85%;*/
							max-height:<xsl:value-of select="concat((($rowHeight - 0.5)*0.9),$defaultUnit)"/>;
							max-width:<xsl:value-of select="concat(($colWidth - 1),$defaultUnit)"/>;
					}
					#endCouv .photo-container{
						padding-top:5cm;
						page-break-after:none;
					}
				}
				
		</style>
			</head>
			<body>
			<xsl:apply-templates select="/photos/couv"  mode="html"/>
				<xsl:call-template name="html-intercalaires"/>
				<xsl:apply-templates select="/photos/pages" mode="html"/>
				<xsl:call-template name="html-intercalaires"/>
				<xsl:apply-templates select="/photos/endCouv"  mode="html"/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="pages//image|endCouv/image" mode="html">
		<div class="photo-container">
			<img class="photo" src="{concat(@path,@href)}" alt="{.}"/>
			<br/>
			<xsl:apply-templates select="*|text()" mode="html"/>
		</div>
	</xsl:template>
	<xsl:template match="pages" mode="html">
		<div id="pages">
			<xsl:choose>
				<xsl:when test="page">
					<xsl:for-each select="page">
						<xsl:call-template name="html-structured-page">
							<xsl:with-param name="imagesList" select="image"/>
						</xsl:call-template>
					</xsl:for-each>
				</xsl:when>
				<xsl:otherwise>
					<xsl:for-each select="image[(position()-1) mod ($tableCols*$tableRows)= 0]">
						<xsl:call-template name="html-structured-page">
							<xsl:with-param name="imagesList" select="following-sibling::image[position() &lt; $tableCols*$tableRows ]|."/>
						</xsl:call-template>
					</xsl:for-each>
				</xsl:otherwise>
			</xsl:choose>
		</div>
	</xsl:template>
	<xsl:template name="html-structured-page">
		<xsl:param name="imagesList"/>
		<xsl:param name="isBreakBefore">
			<xsl:choose>
				<xsl:when test="position()=1">auto</xsl:when>
				<xsl:otherwise>page</xsl:otherwise>
			</xsl:choose>
		</xsl:param>
		<div class="page">
			<table class="photos-table">
				<tbody>
					<xsl:call-template name="html-getColAndRowImagesStruct">
						<xsl:with-param name="imagesList" select="$imagesList"/>
					</xsl:call-template>
				</tbody>
			</table>
		</div>
	</xsl:template>
	<xsl:template name="html-getColAndRowImagesStruct">
		<xsl:param name="imagesList"/>
		<xsl:for-each select="$imagesList[(position()-1) mod $tableRows = 0]">
			<tr class="photos-table-tr">
				<xsl:for-each select=".|following-sibling::image[position() &lt; $tableCols]">
					<td class="photos-table-td">
						<xsl:apply-templates select="." mode="html"/>
					</td>
				</xsl:for-each>
			</tr>
		</xsl:for-each>
	</xsl:template>
	<xsl:template match="fo:*" mode="html">
		<div>
			<xsl:apply-templates select="*|text()"/>
		</div>
	</xsl:template>
	<xsl:template name="html-intercalaires">
		<xsl:if test="/photos/config/intercal='True'">
			<div class="intercal page">&nbsp;</div>
			<div class="intercal page">&nbsp;</div>
		</xsl:if>
	</xsl:template>
	<xsl:template match="couv" mode="html">
		<div class="page" id="couv">
			<div><xsl:value-of select="/photos/title"/></div>
			<img src="{concat(image/@path,image/@href)}" alt="{/photo/title}"/>
		</div>
	</xsl:template>
	<xsl:template match="endCouv" mode="html">
			<div class="page" id="endCouv"><xsl:apply-templates select="image" mode="html"/> </div>
	</xsl:template>
</xsl:stylesheet>
